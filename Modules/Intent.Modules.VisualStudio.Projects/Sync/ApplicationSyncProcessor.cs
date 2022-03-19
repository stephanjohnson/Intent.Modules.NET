﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Intent.Engine;
using Intent.Eventing;
using Intent.Modules.Common.Plugins;
using Intent.Modules.Constants;
using Intent.Modules.VisualStudio.Projects.Api;
using Intent.Modules.VisualStudio.Projects.Events;
using Intent.Plugins.FactoryExtensions;
using Intent.Utils;

namespace Intent.Modules.VisualStudio.Projects.Sync
{
    [Description("Visual Studio Project File Syncer")]
    public class ApplicationSyncProcessor : FactoryExtensionBase, IExecutionLifeCycle
    {
        private readonly ISoftwareFactoryEventDispatcher _sfEventDispatcher;
        private readonly IChanges _changeManager;
        private readonly IXmlFileCache _fileCache;
        private readonly Dictionary<string, List<SoftwareFactoryEvent>> _actions;
        private readonly Dictionary<string, string> _projectFilePathMap = new();

        public override string Id => "Intent.ApplicationSyncProcessor";

        public override int Order { get; set; } = 90;

        public ApplicationSyncProcessor(ISoftwareFactoryEventDispatcher sfEventDispatcher, IXmlFileCache fileCache, IChanges changeManager)
        {
            _changeManager = changeManager;
            _fileCache = fileCache;
            _actions = new Dictionary<string, List<SoftwareFactoryEvent>>();
            _sfEventDispatcher = sfEventDispatcher;
            //Subscribe to all the project change events
            _sfEventDispatcher.Subscribe(SoftwareFactoryEvents.FileAddedEvent, Handle);
            _sfEventDispatcher.Subscribe(SoftwareFactoryEvents.FileRemovedEvent, Handle);
            _sfEventDispatcher.Subscribe(SoftwareFactoryEvents.AddTargetEvent, Handle);
            _sfEventDispatcher.Subscribe(SoftwareFactoryEvents.AddTaskEvent, Handle);
            _sfEventDispatcher.Subscribe(SoftwareFactoryEvents.ChangeProjectItemTypeEvent, Handle);

            _sfEventDispatcher.Subscribe(CsProjectEvents.AddImport, Handle);
            _sfEventDispatcher.Subscribe(CsProjectEvents.AddCompileDependsOn, Handle);
            _sfEventDispatcher.Subscribe(CsProjectEvents.AddBeforeBuild, Handle);
            _sfEventDispatcher.Subscribe(CsProjectEvents.AddContentFile, Handle);

        }

        public void OnStep(IApplication application, string step)
        {
            if (step == ExecutionLifeCycleSteps.BeforeTemplateRegistrations)
            {
                application.EventDispatcher.Subscribe<VisualStudioSolutionProjectCreatedEvent>(HandleEvent);
            }
            if (step == ExecutionLifeCycleSteps.AfterTemplateExecution)
            {
                SyncProjectFiles(application);
            }
        }

        public void SyncProjectFiles(IApplication application)
        {
            foreach (var (outputTargetId, events) in _actions)
            {
                var outputTarget = application.OutputTargets.FirstOrDefault(x => x.Id == outputTargetId);
                if (outputTarget == null)
                {
                    //This scenario occurs when targets have been deleted
                    continue;
                }

                var vsProject = outputTarget.GetTargetPath()[0];
                if (vsProject.Metadata == null ||
                    !vsProject.Metadata.TryGetValue(ProjectConfig.MetadataKey.IsMatch, out var value) ||
                    value is not true)
                {
                    continue;
                }

                switch (vsProject.Type)
                {
                    case VisualStudioProjectTypeIds.CSharpLibrary:
                    case VisualStudioProjectTypeIds.ConsoleAppNetFramework:
                    case VisualStudioProjectTypeIds.NodeJsConsoleApplication:
                    case VisualStudioProjectTypeIds.WcfApplication:
                    case VisualStudioProjectTypeIds.WebApiApplication:
                        new FrameworkProjectSyncProcessor(_projectFilePathMap[vsProject.Id], _sfEventDispatcher, _fileCache, _changeManager, vsProject).Process(events);
                        break;
                    case VisualStudioProjectTypeIds.CoreCSharpLibrary:
                    case VisualStudioProjectTypeIds.CoreWebApp:
                    case VisualStudioProjectTypeIds.CoreConsoleApp:
                    case VisualStudioProjectTypeIds.AzureFunctionsProject:
                        new CoreProjectSyncProcessor(_projectFilePathMap[vsProject.Id], _sfEventDispatcher, _fileCache, _changeManager, vsProject).Process(events);
                        break;
                    case VisualStudioProjectTypeIds.SQLServerDatabaseProject:
                        new SqlProjectSyncProcessor(_projectFilePathMap[vsProject.Id], _sfEventDispatcher, _fileCache, _changeManager).Process(events);
                        break;
                    default:
                        Logging.Log.Warning("No project synchronizer could be found for project: " + vsProject.Name);
                        continue;
                }
            }

            _actions.Clear();
        }

        private void HandleEvent(VisualStudioSolutionProjectCreatedEvent @event)
        {
            if (_projectFilePathMap.ContainsKey(@event.ProjectId))
            {
                throw new Exception($"Attempted to add project with same project Id [{@event.ProjectId}] (location: {@event.FilePath})");
            }
            _projectFilePathMap.Add(@event.ProjectId, @event.FilePath);
        }

        public void Handle(SoftwareFactoryEvent @event)
        {
            var outputTargetId = @event.GetValue("OutputTargetId");
            if (!_actions.ContainsKey(outputTargetId))
            {
                _actions[outputTargetId] = new List<SoftwareFactoryEvent>();
            }
            _actions[outputTargetId].Add(@event);
        }
    }
}
