// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.Eventing.MassTransit.Templates.IntegrationEventHandlerImplementation
{
    using System.Collections.Generic;
    using System.Linq;
    using Intent.Modules.Common;
    using Intent.Modules.Common.Templates;
    using Intent.Modules.Common.CSharp.Templates;
    using Intent.Templates;
    using Intent.Metadata.Models;
    using Intent.Modules.Eventing.Contracts.Templates;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Eventing.MassTransit\Templates\IntegrationEventHandlerImplementation\IntegrationEventHandlerImplementationTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class IntegrationEventHandlerImplementationTemplate : CSharpTemplateBase<Intent.Modelers.Eventing.Api.MessageSubscribeAssocationTargetEndModel>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("using System;\r\nusing System.Threading;\r\nusing System.Threading.Tasks;\r\n\r\n[assembly: DefaultIntentManaged(Mode.Fully)]\r\n\r\nnamespace ");
            
            #line 17 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Eventing.MassTransit\Templates\IntegrationEventHandlerImplementation\IntegrationEventHandlerImplementationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]\r\n    public class ");
            
            #line 20 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Eventing.MassTransit\Templates\IntegrationEventHandlerImplementation\IntegrationEventHandlerImplementationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(" : ");
            
            #line 20 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Eventing.MassTransit\Templates\IntegrationEventHandlerImplementation\IntegrationEventHandlerImplementationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.GetIntegrationEventHandlerInterfaceName()));
            
            #line default
            #line hidden
            this.Write("<");
            
            #line 20 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Eventing.MassTransit\Templates\IntegrationEventHandlerImplementation\IntegrationEventHandlerImplementationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetMessageName()));
            
            #line default
            #line hidden
            this.Write(">\r\n    {\r\n        [IntentManaged(Mode.Ignore)]\r\n        public ");
            
            #line 23 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Eventing.MassTransit\Templates\IntegrationEventHandlerImplementation\IntegrationEventHandlerImplementationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("()\r\n        {\r\n        }\r\n        \r\n        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]\r\n        public async Task HandleAsync(");
            
            #line 28 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Eventing.MassTransit\Templates\IntegrationEventHandlerImplementation\IntegrationEventHandlerImplementationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetMessageName()));
            
            #line default
            #line hidden
            this.Write(" message, CancellationToken cancellationToken = default)\r\n        {\r\n            throw new NotImplementedException(); \r\n        }\r\n    }\r\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
}
