﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 17.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.VisualStudio.Projects.Templates.CSharpProject
{
    using Intent.Modules.Common.Templates;
    using Intent.Modules.Common.VisualStudio;
    using System;
    using System.IO;
    using System.Diagnostics;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    using Intent.Modules.VisualStudio.Projects.Api;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.VisualStudio.Projects\Templates\CSharpProject\CSharpProjectTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class CSharpProjectTemplate : VisualStudioProjectTemplateBase<CSharpProjectNETModel>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write(" \r\n");
            this.Write(" \r\n");
            this.Write("\r\n<Project Sdk=\"Microsoft.NET.Sdk\">\r\n\r\n  <PropertyGroup>\r\n    <TargetFramework>");
            
            #line 17 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.VisualStudio.Projects\Templates\CSharpProject\CSharpProjectTemplate.tt"
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