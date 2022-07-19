﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.AzureFunctions.Templates.AzureFunctionClass
{
    using System.Collections.Generic;
    using System.Linq;
    using Intent.Modules.Common;
    using Intent.Modules.Common.Templates;
    using Intent.Modules.Common.CSharp.Templates;
    using Intent.Templates;
    using Intent.Metadata.Models;
    using Intent.AzureFunctions.Api;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.AzureFunctions\Templates\AzureFunctionClass\AzureFunctionClassTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class AzureFunctionClassTemplate : CSharpTemplateBase
        <Intent.Modelers.Services.Api.OperationModel,
            Intent.Modules.AzureFunctions.Templates.AzureFunctionClass.AzureFunctionClassDecorator>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("using System;\r\nusing System.Collections.Generic;\r\nusing System.IO;\r\nusing System.Threading.Tasks;\r\nusing Microsoft.AspNetCore.Mvc;\r\nusing Microsoft.AspNetCore.Http;\r\nusing Microsoft.Azure.WebJobs;\r\nusing Microsoft.Azure.WebJobs.Extensions.Http;\r\nusing Microsoft.Extensions.Logging;\r\nusing Newtonsoft.Json;\r\n\r\n[assembly: DefaultIntentManaged(Mode.Fully)]\r\n\r\nnamespace ");
            
            #line 27 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.AzureFunctions\Templates\AzureFunctionClass\AzureFunctionClassTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    public class ");
            
            #line 29 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.AzureFunctions\Templates\AzureFunctionClass\AzureFunctionClassTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("\r\n    {");
            
            #line 30 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.AzureFunctions\Templates\AzureFunctionClass\AzureFunctionClassTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetClassEntryDefinitionList()));
            
            #line default
            #line hidden
            this.Write("\r\n        public ");
            
            #line 31 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.AzureFunctions\Templates\AzureFunctionClass\AzureFunctionClassTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("(");
            
            #line 31 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.AzureFunctions\Templates\AzureFunctionClass\AzureFunctionClassTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetConstructorParameterDefinitionList()));
            
            #line default
            #line hidden
            this.Write(")\r\n        {");
            
            #line 32 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.AzureFunctions\Templates\AzureFunctionClass\AzureFunctionClassTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetConstructorBodyStatementList()));
            
            #line default
            #line hidden
            this.Write("\r\n        }\r\n\r\n        [FunctionName(\"");
            
            #line 35 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.AzureFunctions\Templates\AzureFunctionClass\AzureFunctionClassTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("\")]\r\n        public async ");
            
            #line 36 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.AzureFunctions\Templates\AzureFunctionClass\AzureFunctionClassTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetRunMethodReturnType()));
            
            #line default
            #line hidden
            this.Write(" Run(");
            
            #line 36 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.AzureFunctions\Templates\AzureFunctionClass\AzureFunctionClassTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetRunMethodParameterDefinitionList()));
            
            #line default
            #line hidden
            this.Write(")\r\n        {");
            
            #line 37 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.AzureFunctions\Templates\AzureFunctionClass\AzureFunctionClassTemplate.tt"

    if (HasExceptionCatchBlocks())
    {

            
            #line default
            #line hidden
            this.Write("            try\r\n            {\r\n");
            
            #line 43 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.AzureFunctions\Templates\AzureFunctionClass\AzureFunctionClassTemplate.tt"

    }

            
            #line default
            #line hidden
            
            #line 45 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.AzureFunctions\Templates\AzureFunctionClass\AzureFunctionClassTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetRunMethodEntryStatementList()));
            
            #line default
            #line hidden
            this.Write("\r\n            ");
            
            #line 46 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.AzureFunctions\Templates\AzureFunctionClass\AzureFunctionClassTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetRunMethodBodyStatementList()));
            
            #line default
            #line hidden
            this.Write("\r\n            ");
            
            #line 47 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.AzureFunctions\Templates\AzureFunctionClass\AzureFunctionClassTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetRunMethodExitStatementList()));
            
            #line default
            #line hidden
            
            #line 47 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.AzureFunctions\Templates\AzureFunctionClass\AzureFunctionClassTemplate.tt"

    if (HasExceptionCatchBlocks())
    {

            
            #line default
            #line hidden
            this.Write("            }\r\n            ");
            
            #line 52 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.AzureFunctions\Templates\AzureFunctionClass\AzureFunctionClassTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetExceptionCatchBlocks()));
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 53 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.AzureFunctions\Templates\AzureFunctionClass\AzureFunctionClassTemplate.tt"

    }

            
            #line default
            #line hidden
            this.Write("        }\r\n    }\r\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
}