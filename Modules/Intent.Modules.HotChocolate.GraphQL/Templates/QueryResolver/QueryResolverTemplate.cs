// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 17.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.HotChocolate.GraphQL.Templates.QueryResolver
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
    
    #line 1 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.HotChocolate.GraphQL\Templates\QueryResolver\QueryResolverTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class QueryResolverTemplate : CSharpTemplateBase<Intent.Modelers.Services.Api.ServiceModel>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("using HotChocolate;\r\nusing HotChocolate.Types;\r\nusing System.Collections.Generic;" +
                    "\r\nusing System.Threading.Tasks;\r\n\r\n[assembly: DefaultIntentManaged(Mode.Fully)]\r" +
                    "\n\r\nnamespace ");
            
            #line 17 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.HotChocolate.GraphQL\Templates\QueryResolver\QueryResolverTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    [ExtendObjectType(\"Query\")]\r\n    public class ");
            
            #line 20 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.HotChocolate.GraphQL\Templates\QueryResolver\QueryResolverTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("\r\n    {");
            
            #line 21 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.HotChocolate.GraphQL\Templates\QueryResolver\QueryResolverTemplate.tt"
  
    foreach(var operation in Model.Operations.Where(IsQuery)) { 
            
            #line default
            #line hidden
            this.Write("\r\n        public ");
            
            #line 24 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.HotChocolate.GraphQL\Templates\QueryResolver\QueryResolverTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetReturnType(operation)));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 24 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.HotChocolate.GraphQL\Templates\QueryResolver\QueryResolverTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(operation.Name.ToPascalCase()));
            
            #line default
            #line hidden
            this.Write("(");
            
            #line 24 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.HotChocolate.GraphQL\Templates\QueryResolver\QueryResolverTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetParameters(operation)));
            
            #line default
            #line hidden
            this.Write(")\r\n        {");
            
            #line 25 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.HotChocolate.GraphQL\Templates\QueryResolver\QueryResolverTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetImplementation(operation)));
            
            #line default
            #line hidden
            this.Write("\r\n        }\r\n");
            
            #line 27 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.HotChocolate.GraphQL\Templates\QueryResolver\QueryResolverTemplate.tt"
  }
            
            #line default
            #line hidden
            this.Write("    }\r\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
