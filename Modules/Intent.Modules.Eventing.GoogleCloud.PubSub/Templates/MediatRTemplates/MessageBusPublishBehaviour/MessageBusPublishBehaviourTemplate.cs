//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:6.0.13
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Intent.Modules.Eventing.GoogleCloud.PubSub.Templates.MediatRTemplates.MessageBusPublishBehaviour {
    using System.Collections.Generic;
    using System.Linq;
    using Intent.Modules.Common;
    using Intent.Modules.Common.Templates;
    using Intent.Modules.Common.CSharp.Templates;
    using Intent.Templates;
    using Intent.Metadata.Models;
    using Intent.Modules.Eventing.Contracts.Templates;
    using System;
    
    
    public partial class MessageBusPublishBehaviourTemplate : CSharpTemplateBase<object> {
        
        public override string TransformText() {
            this.GenerationEnvironment = null;
            
            #line 11 ""
            this.Write("using System.Threading;\r\nusing System.Threading.Tasks;\r\nusing MediatR;\r\n\r\n[assemb" +
                    "ly: DefaultIntentManaged(Mode.Fully)]\r\n\r\nnamespace ");
            
            #line default
            #line hidden
            
            #line 17 ""
            this.Write(this.ToStringHelper.ToStringWithCulture( Namespace ));
            
            #line default
            #line hidden
            
            #line 17 ""
            this.Write(";\r\n\r\npublic class ");
            
            #line default
            #line hidden
            
            #line 19 ""
            this.Write(this.ToStringHelper.ToStringWithCulture( ClassName ));
            
            #line default
            #line hidden
            
            #line 19 ""
            this.Write("<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>\r\nwhere TRequest : " +
                    "IRequest<TResponse>\r\n{\r\n    private readonly ");
            
            #line default
            #line hidden
            
            #line 22 ""
            this.Write(this.ToStringHelper.ToStringWithCulture( this.GetEventBusInterfaceName() ));
            
            #line default
            #line hidden
            
            #line 22 ""
            this.Write(" _eventBus;\r\n\r\n    public ");
            
            #line default
            #line hidden
            
            #line 24 ""
            this.Write(this.ToStringHelper.ToStringWithCulture( ClassName ));
            
            #line default
            #line hidden
            
            #line 24 ""
            this.Write("(");
            
            #line default
            #line hidden
            
            #line 24 ""
            this.Write(this.ToStringHelper.ToStringWithCulture( this.GetEventBusInterfaceName() ));
            
            #line default
            #line hidden
            
            #line 24 ""
            this.Write(@" eventBus)
    {
        _eventBus = eventBus;
    }
    
    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        var response = await next();

        await _eventBus.FlushAllAsync(cancellationToken);

        return response;
    }
}");
            
            #line default
            #line hidden
            return this.GenerationEnvironment.ToString();
        }
        
        public override void Initialize() {
            base.Initialize();
        }
    }
}