// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 17.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.Entities.Templates.CollectionWrapper
{
    using System.Collections.Generic;
    using System.Linq;
    using Intent.Modules.Common;
    using Intent.Modules.Common.Templates;
    using Intent.Modules.Common.CSharp.Templates;
    using Intent.Templates;
    using Intent.Metadata.Models;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Entities\Templates\CollectionWrapper\CollectionWrapperTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class CollectionWrapperTemplate : CSharpTemplateBase<object>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("using System.Collections;\r\nusing System.Collections.Generic;\r\nusing System.Linq;\r" +
                    "\n\r\n[assembly: DefaultIntentManaged(Mode.Fully)]\r\n\r\nnamespace ");
            
            #line 16 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Entities\Templates\CollectionWrapper\CollectionWrapperTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    public class ");
            
            #line 18 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Entities\Templates\CollectionWrapper\CollectionWrapperTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("<TInterface, TImplementation> : ICollection<TInterface>\r\n        where TImplement" +
                    "ation: TInterface\r\n    {\r\n        private readonly ICollection<TImplementation> " +
                    "_wrappedCollection;\r\n\r\n        public ");
            
            #line 23 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Entities\Templates\CollectionWrapper\CollectionWrapperTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(@"(ICollection<TImplementation> wrappedCollection)
        {
            _wrappedCollection = wrappedCollection;
        }
        public IEnumerator<TInterface> GetEnumerator()
        {
            return _wrappedCollection.Cast<TInterface>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(TInterface item)
        {
            _wrappedCollection.Add((TImplementation)item!);
        }

        public void Clear()
        {
            _wrappedCollection.Clear();
        }

        public bool Contains(TInterface item)
        {
            return _wrappedCollection.Contains((TImplementation)item!);
        }

        public void CopyTo(TInterface[] array, int arrayIndex)
        {
            _wrappedCollection.Cast<TInterface>().ToArray().CopyTo(array, arrayIndex);
        }

        public bool Remove(TInterface item)
        {
            return _wrappedCollection.Remove((TImplementation)item!);
        }

        public int Count => _wrappedCollection.Count;
        public bool IsReadOnly => _wrappedCollection.IsReadOnly;
    }

    public static class CollectionExtensions
    {
        public static ICollection<TInterface> CreateWrapper<TInterface, TImplementation>(this ICollection<TImplementation> collection) 
            where TImplementation : TInterface
        {
            return new ");
            
            #line 71 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Entities\Templates\CollectionWrapper\CollectionWrapperTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("<TInterface, TImplementation>(collection);\r\n        }\r\n    }\r\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
