// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.Eventing.MassTransit.Templates.EventMessage
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
    
    #line 1 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Eventing.MassTransit\Templates\EventMessage\EventMessageTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class EventMessageTemplate : CSharpTemplateBase<Intent.Modelers.Eventing.Api.MessageModel>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("\r\n[assembly: DefaultIntentManaged(Mode.Fully)]\r\n\r\nnamespace ");
            
            #line 13 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Eventing.MassTransit\Templates\EventMessage\EventMessageTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    public record ");
            
            #line 15 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Eventing.MassTransit\Templates\EventMessage\EventMessageTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("\r\n    {\r\n");
            
            #line 17 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Eventing.MassTransit\Templates\EventMessage\EventMessageTemplate.tt"

    foreach (var property in Model.Properties)
    {

            
            #line default
            #line hidden
            this.Write("        public ");
            
            #line 21 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Eventing.MassTransit\Templates\EventMessage\EventMessageTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetTypeName(property.TypeReference)));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 21 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Eventing.MassTransit\Templates\EventMessage\EventMessageTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(property.Name.ToPascalCase()));
            
            #line default
            #line hidden
            this.Write(" { get; init; }\r\n");
            
            #line 22 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Eventing.MassTransit\Templates\EventMessage\EventMessageTemplate.tt"

    }

            
            #line default
            #line hidden
            this.Write("    }\r\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
}