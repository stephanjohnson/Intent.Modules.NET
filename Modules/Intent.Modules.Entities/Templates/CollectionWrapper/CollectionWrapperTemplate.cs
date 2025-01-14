﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
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
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class CollectionWrapperTemplate : CSharpTemplateBase<object>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("using System.Collections;\r\nusing System.Collections.Generic;\r\nusing System.Linq;\r\n\r\n[assembly: DefaultIntentManaged(Mode.Fully)]\r\n\r\nnamespace ");
            
            #line 16 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Entities\Templates\CollectionWrapper\CollectionWrapperTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    public class ");
            
            #line 18 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Entities\Templates\CollectionWrapper\CollectionWrapperTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("<TInterface, TImplementation> : ICollection<TInterface>\r\n        where TImplementation: TInterface\r\n    {\r\n        private readonly ICollection<TImplementation> _wrappedCollection;\r\n\r\n        public ");
            
            #line 23 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Entities\Templates\CollectionWrapper\CollectionWrapperTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("(ICollection<TImplementation> wrappedCollection)\r\n        {\r\n            _wrappedCollection = wrappedCollection;\r\n        }\r\n        public IEnumerator<TInterface> GetEnumerator()\r\n        {\r\n            return _wrappedCollection.Cast<TInterface>().GetEnumerator();\r\n        }\r\n\r\n        IEnumerator IEnumerable.GetEnumerator()\r\n        {\r\n            return GetEnumerator();\r\n        }\r\n\r\n        public void Add(TInterface item)\r\n        {\r\n            _wrappedCollection.Add((TImplementation)item!);\r\n        }\r\n\r\n        public void Clear()\r\n        {\r\n            _wrappedCollection.Clear();\r\n        }\r\n\r\n        public bool Contains(TInterface item)\r\n        {\r\n            return _wrappedCollection.Contains((TImplementation)item!);\r\n        }\r\n\r\n        public void CopyTo(TInterface[] array, int arrayIndex)\r\n        {\r\n            _wrappedCollection.Cast<TInterface>().ToArray().CopyTo(array, arrayIndex);\r\n        }\r\n\r\n        public bool Remove(TInterface item)\r\n        {\r\n            return _wrappedCollection.Remove((TImplementation)item!);\r\n        }\r\n\r\n        public int Count => _wrappedCollection.Count;\r\n        public bool IsReadOnly => _wrappedCollection.IsReadOnly;\r\n    }\r\n\r\n    public static class ");
            
            #line 66 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Entities\Templates\CollectionWrapper\CollectionWrapperTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("Extensions\r\n    {\r\n        public static ICollection<TInterface> CreateWrapper<TInterface, TImplementation>(this ICollection<TImplementation> collection) \r\n            where TImplementation : TInterface\r\n        {\r\n            return new ");
            
            #line 71 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Entities\Templates\CollectionWrapper\CollectionWrapperTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("<TInterface, TImplementation>(collection);\r\n        }\r\n    }\r\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
}
