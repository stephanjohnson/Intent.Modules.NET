//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:6.0.13
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Intent.Modules.Eventing.GoogleCloud.PubSub.Templates.InterfaceTemplates.CloudResourceManagerInterface {
    using System.Collections.Generic;
    using System.Linq;
    using Intent.Modules.Common;
    using Intent.Modules.Common.Templates;
    using Intent.Modules.Common.CSharp.Templates;
    using Intent.Templates;
    using Intent.Metadata.Models;
    using System;
    
    
    public partial class CloudResourceManagerInterfaceTemplate : CSharpTemplateBase<object> {
        
        public override string TransformText() {
            this.GenerationEnvironment = null;
            
            #line 10 ""
            this.Write("using System;\r\nusing System.Threading;\r\nusing System.Threading.Tasks;\r\n\r\n[assembl" +
                    "y: DefaultIntentManaged(Mode.Fully)]\r\n\r\nnamespace ");
            
            #line default
            #line hidden
            
            #line 16 ""
            this.Write(this.ToStringHelper.ToStringWithCulture( Namespace ));
            
            #line default
            #line hidden
            
            #line 16 ""
            this.Write(";\r\n\r\npublic interface ");
            
            #line default
            #line hidden
            
            #line 18 ""
            this.Write(this.ToStringHelper.ToStringWithCulture( ClassName ));
            
            #line default
            #line hidden
            
            #line 18 ""
            this.Write(@"
{
    string ProjectId { get; }
    bool ShouldSetupCloudResources { get; }
    Task CreateTopicIfNotExistAsync(string topicId, CancellationToken cancellationToken = default);
    Task CreateSubscriptionIfNotExistAsync((string SubscriptionId, string TopicId) subscription, CancellationToken cancellationToken = default);
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