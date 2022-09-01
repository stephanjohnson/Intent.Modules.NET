//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:6.0.8
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Intent.Modules.Eventing.MassTransit.Templates.EventBusInterface {
    using System.Collections.Generic;
    using System.Linq;
    using Intent.Modules.Common;
    using Intent.Modules.Common.Templates;
    using Intent.Modules.Common.CSharp.Templates;
    using Intent.Templates;
    using Intent.Metadata.Models;
    using System;
    
    
    public partial class EventBusInterfaceTemplate : CSharpTemplateBase<object> {
        
        public override string TransformText() {
            this.GenerationEnvironment = null;
            
            #line 10 ""
            this.Write("using System.Threading;\r\nusing System.Threading.Tasks;\r\n\r\n[assembly: DefaultInten" +
                    "tManaged(Mode.Fully)]\r\n\r\nnamespace ");
            
            #line default
            #line hidden
            
            #line 15 ""
            this.Write(this.ToStringHelper.ToStringWithCulture( Namespace ));
            
            #line default
            #line hidden
            
            #line 15 ""
            this.Write("\r\n{\r\n    public interface ");
            
            #line default
            #line hidden
            
            #line 17 ""
            this.Write(this.ToStringHelper.ToStringWithCulture( ClassName ));
            
            #line default
            #line hidden
            
            #line 17 ""
            this.Write("\r\n    {\r\n        void Publish<T>(T message) where T : class;\r\n\r\n        Task Flus" +
                    "hAllAsync(CancellationToken cancellationToken = default);\r\n    }\r\n}");
            
            #line default
            #line hidden
            return this.GenerationEnvironment.ToString();
        }
        
        public override void Initialize() {
            base.Initialize();
        }
    }
}