// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.VisualStudio.Projects.Templates.CoreConsoleApp
{
    using System.Collections.Generic;
    using System.Linq;
    using Intent.Modules.Common;
    using Intent.Modules.Common.Templates;
    using Intent.Metadata.Models;
    using Intent.Modules.VisualStudio.Projects.Templates;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.VisualStudio.Projects\Templates\CoreConsoleApp\CoreConsoleAppTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class CoreConsoleAppTemplate : VisualStudioProjectTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("<Project Sdk=\"Microsoft.NET.Sdk\">\r\n\r\n  <PropertyGroup>\r\n    <OutputType>Exe</Outp" +
                    "utType>\r\n    <TargetFramework>");
            
            #line 13 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.VisualStudio.Projects\Templates\CoreConsoleApp\CoreConsoleAppTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(string.Join(";", Model.TargetFrameworkVersion())));
            
            #line default
            #line hidden
            this.Write("</TargetFramework>\r\n  </PropertyGroup>\r\n\r\n</Project>\r\n");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
