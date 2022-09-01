// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.CloudStorageClient.Templates.CloudStorageInterface
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
    
    #line 1 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.CloudStorageClient\Templates\CloudStorageInterface\CloudStorageInterfaceTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class CloudStorageInterfaceTemplate : CSharpTemplateBase<object>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("using System;\r\nusing System.IO;\r\nusing System.Threading;\r\nusing System.Threading.Tasks;\r\n\r\n[assembly: DefaultIntentManaged(Mode.Fully)]\r\n\r\nnamespace ");
            
            #line 18 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.CloudStorageClient\Templates\CloudStorageInterface\CloudStorageInterfaceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    public interface ");
            
            #line 20 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.CloudStorageClient\Templates\CloudStorageInterface\CloudStorageInterfaceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("\r\n    {\r\n        Task<Stream> DownloadContentAsync(Uri cloudStorageLocation, CancellationToken cancellationToken = default);\r\n        Task<Stream> DownloadContentAsync(string containerName, string blobName, CancellationToken cancellationToken = default);\r\n        Task UploadContent(Uri cloudStorageLocation, Stream streamToUpload, bool overwrite = true, CancellationToken cancellationToken = default);\r\n        Task UploadContent(string containerName, string blobName, Stream streamToUpload, bool overwrite = true, CancellationToken cancellationToken = default);\r\n    }\r\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
}
