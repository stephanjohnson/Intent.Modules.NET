﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Intent.Modules.VisualStudio.Projects.SolutionFile
{
    internal class SlnFile
    {
        private readonly string _originalOutput;

        public SlnFile(string path, string content)
        {
            FilePath = Path.GetFullPath(path);
            Parse(content);
            _originalOutput = GetOutput();
        }

        public List<Node> Nodes { get; set; } = new();

        public string FilePath { get; set; }

        public bool IsChanged => _originalOutput != GetOutput();

        private string GetOutput()
        {
            var writer = new Writer();
            foreach (var node in Nodes)
            {
                node.Visit(writer);
            }

            return writer.ToString();
        }

        public void Parse(string content)
        {
            var lines = content.TrimEnd().Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            var queue = new Queue<string>(lines);
            var parsers = new INodeParser[]
            {
                new CommentNode.Parser(),
                new HeaderNode.Parser(),
                new SolutionItemComplexNode.Parser(),
                new SolutionItemSimpleNode.Parser(),
                new SolutionItemSectionNode.Parser(),
                new KeyValueNode.Parser(),
                new WhitespaceNode.Parser()
            };

            List<Node> GetChildNodes()
            {
                var childNodes = new List<Node>();

                while (queue.TryDequeue(out var line))
                {
                    if (line.Trim().StartsWith("End"))
                    {
                        break;
                    }

                    var parsed = false;

                    foreach (var parser in parsers)
                    {
                        if (!parser.TryParse(line, queue, GetChildNodes, out var node))
                        {
                            continue;
                        }

                        parsed = true;
                        childNodes.Add(node);
                        break;
                    }

                    if (!parsed)
                    {
                        throw new Exception($"Could not parse: {line}");
                    }
                }

                return childNodes;
            }

            while (queue.TryDequeue(out var line))
            {
                var parsed = false;

                foreach (var parser in parsers)
                {
                    if (!parser.TryParse(line, queue, GetChildNodes, out var node))
                    {
                        continue;
                    }

                    parsed = true;
                    Nodes.Add(node);
                    break;
                }

                if (!parsed)
                {
                    throw new Exception($"Could not parse: {line}");
                }
            }
        }

        // For removing files from a solution folder
        public void RemoveSolutionItem(string solutionFolderName, string filePath)
        {
            var relativePath = GetRelativePath(filePath);

            var solutionFolderNode = Nodes
                .OfType<SolutionItemComplexNode>()
                .SingleOrDefault(node =>
                    node.Parameter == "{2150E333-8FDC-42A3-9474-1A3956D46DE8}" && // This guid is for solution folders
                    node.Values[0] == solutionFolderName);

            if (solutionFolderNode == null)
            {
                throw new Exception($"Could not find solution folder with name '{solutionFolderName}'");
            }

            if (!solutionFolderNode.ChildNodes.Any())
            {
                return;
            }

            var childNodes = solutionFolderNode.ChildNodes.OfType<SolutionItemSectionNode>().Single().ChildNodes;
            var toRemove = childNodes.SingleOrDefault(x => x is KeyValueNode node && node.Key == relativePath);
            if (toRemove == null)
            {
                return;
            }

            childNodes.Remove(toRemove);
            if (childNodes.Any())
            {
                return;
            }

            solutionFolderNode.ChildNodes.Clear();
        }

        // For adding files to a solution folder
        public void AddSolutionItem(string solutionFolderName, string filePath)
        {
            var relativePath = GetRelativePath(filePath);

            var solutionFolderNode = Nodes
                .OfType<SolutionItemComplexNode>()
                .SingleOrDefault(node =>
                    node.Parameter == "{2150E333-8FDC-42A3-9474-1A3956D46DE8}" && // This guid is for solution folders
                    node.Values[0] == solutionFolderName);

            if (solutionFolderNode == null)
            {
                throw new Exception($"Could not find solution folder with name '{solutionFolderName}'");
            }

            if (!solutionFolderNode.ChildNodes.Any())
            {
                solutionFolderNode.ChildNodes.Add(new SolutionItemSectionNode(
                    name: "ProjectSection",
                    sectionName: "SolutionItems",
                    value: "preProject",
                    childNodes: new List<Node>()));
            }

            var childNodes = solutionFolderNode.ChildNodes.OfType<SolutionItemSectionNode>().Single().ChildNodes;
            if (!childNodes.Any(x => x is KeyValueNode node && node.Key == relativePath))
            {
                // Insert in order: https://stackoverflow.com/a/12172412/706555
                var index = childNodes
                    .OfType<KeyValueNode>()
                    .Select(x => x.Key)
                    .ToList()
                    .BinarySearch(relativePath);
                if (index < 0)
                {
                    index = ~index;
                }

                childNodes.Insert(index, new KeyValueNode(relativePath, relativePath));
            }
        }

        private string GetRelativePath(string filePath)
        {
            // .sln files always use forward slashes
            return Path.GetRelativePath(Path.GetDirectoryName(FilePath), filePath).Replace("/", "\\");
        }

        public IReadOnlyCollection<SolutionItemComplexNode> GetChildrenWithParentOf(SolutionItemComplexNode node)
        {
            var globalNode = Nodes.OfType<SolutionItemSimpleNode>().SingleOrDefault();
            var section = globalNode?.ChildNodes.OfType<SolutionItemSectionNode>().SingleOrDefault(x => x.SectionName == "NestedProjects");
            var items = (section?.ChildNodes.OfType<KeyValueNode>() ??
                         Enumerable.Empty<KeyValueNode>())
                .ToDictionary(x => x.Key, x => x.Value);

            if (node == null)
            {
                return Nodes.OfType<SolutionItemComplexNode>()
                    .Where(x => !items.ContainsKey(x.Id))
                    .ToArray();
            }

            return items
                .Where(x => x.Value == node.Id)
                .Select(x => Nodes.OfType<SolutionItemComplexNode>().SingleOrDefault(y => x.Key == y.Id))
                .Where(x => x != null)
                .ToArray();
        }

        public void SetParent(SolutionItemComplexNode child, SolutionItemComplexNode parent)
        {
            var globalNode = Nodes.OfType<SolutionItemSimpleNode>().SingleOrDefault();
            if (parent == null)
            {
                var section = globalNode?.ChildNodes.OfType<SolutionItemSectionNode>().SingleOrDefault(x => x.SectionName == "NestedProjects");

                var itemToRemove = section?.ChildNodes.OfType<KeyValueNode>().SingleOrDefault(x => x.Key == child.Id);
                if (itemToRemove == null)
                {
                    return;
                }

                section.ChildNodes.Remove(itemToRemove);
                return;
            }

            GetOrCreateGlobalNode("Global", out globalNode);
            globalNode.GetOrCreateSection(
                name: "NestedProjects",
                value: "preSolution",
                childNodes: new List<Node>(),
                sectionNode: out var nestedProjects);

            var node = nestedProjects.ChildNodes.OfType<KeyValueNode>().SingleOrDefault(x => x.Key == child.Id);
            if (node == null)
            {
                node = new KeyValueNode(child.Id, parent.Id);
                nestedProjects.ChildNodes.Add(node);
                return;
            }

            node.Value = parent.Id;
        }

        public SolutionItemComplexNode GetParent(SolutionItemComplexNode child)
        {
            var globalNode = Nodes.OfType<SolutionItemSimpleNode>().SingleOrDefault();
            var section = globalNode?.ChildNodes.OfType<SolutionItemSectionNode>().SingleOrDefault(x => x.SectionName == "NestedProjects");
            var parentId = section?.ChildNodes.OfType<KeyValueNode>().SingleOrDefault(x => x.Key == child.Id)?.Value;

            return Nodes.OfType<SolutionItemComplexNode>().SingleOrDefault(x => x.Id == parentId);
        }

        /// <returns><see langword="true"/> if the project already existed.</retu,rns>
        public bool GetOrCreateProjectNode(
            string typeId,
            string name,
            string path,
            string id,
            string parentId,
            out SolutionItemProjectNode project,
            bool tryMatchOnPathGlobally = true)
        {
            var parentNode = Nodes.OfType<SolutionItemComplexNode>().SingleOrDefault(x => x.Id == parentId);
            var childNodes = GetChildrenWithParentOf(parentNode);

            var projectNodes = Nodes
                .OfType<SolutionItemComplexNode>()
                .Where(x => x.Name == "Project")
                .ToArray();

            id = $"{{{id}}}".ToUpperInvariant();

            var node =
                childNodes.SingleOrDefault(x => x.Id == id) ??
                childNodes.SingleOrDefault(x => new SolutionItemProjectNode(x).HasPath(path)) ??
                projectNodes.SingleOrDefault(x => x.Id == id);

            if (tryMatchOnPathGlobally)
            {
                node ??= projectNodes.SingleOrDefault(x => new SolutionItemProjectNode(x).HasPath(path));
            }

            if (node != null)
            {
                project = new SolutionItemProjectNode(node);
                return true;
            }

            project = new SolutionItemProjectNode(typeId, name, path, id);

            SetParent(project.UnderlyingNode, parentNode);

            if (projectNodes.Length != 0)
            {
                Nodes.Insert(
                    index: Nodes.IndexOf(projectNodes[projectNodes.Length - 1]) + 1,
                    item: project.UnderlyingNode);

                return false;
            }

            var lastLeadingNode = Nodes
                .TakeWhile(x => x is HeaderNode or CommentNode or WhitespaceNode or KeyValueNode)
                .LastOrDefault();
            if (lastLeadingNode != null)
            {
                Nodes.Insert(
                    index: Nodes.IndexOf(lastLeadingNode) + 1,
                    item: project.UnderlyingNode);

                return false;
            }

            Nodes.Insert(0, project.UnderlyingNode);
            return false;
        }

        public bool GetOrCreateGlobalNode(string name, out SolutionItemSimpleNode globalNode)
        {
            globalNode = Nodes
                .OfType<SolutionItemSimpleNode>()
                .SingleOrDefault(x => x.Name == name);

            if (globalNode != null)
            {
                return true;
            }

            globalNode = new SolutionItemSimpleNode(name, new List<Node>());
            Nodes.Add(globalNode);

            return false;
        }

        public override string ToString() => GetOutput();
    }
}
