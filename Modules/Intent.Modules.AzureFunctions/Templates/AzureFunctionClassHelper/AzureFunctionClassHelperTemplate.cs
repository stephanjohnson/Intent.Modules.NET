﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.AzureFunctions.Templates.AzureFunctionClassHelper
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
    
    #line 1 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.AzureFunctions\Templates\AzureFunctionClassHelper\AzureFunctionClassHelperTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class AzureFunctionClassHelperTemplate : CSharpTemplateBase<object>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("\r\n[assembly: DefaultIntentManaged(Mode.Fully)]\r\n\r\nnamespace ");
            
            #line 13 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.AzureFunctions\Templates\AzureFunctionClassHelper\AzureFunctionClassHelperTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    static class ");
            
            #line 15 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.AzureFunctions\Templates\AzureFunctionClassHelper\AzureFunctionClassHelperTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("\r\n    {\r\n        public static T GetQueryParam<T>(string paramName, IQueryCollection query, ParseDelegate<T> parse)\r\n            where T : struct\r\n        {\r\n            var strVal = query[paramName];\r\n            if (string.IsNullOrEmpty(strVal) || !parse(strVal, out T parsed))\r\n            {\r\n                throw new FormatException($\"Parameter '{paramName}' could not be parsed as a {typeof(T).Name}.\");\r\n            }\r\n\r\n            return parsed;\r\n        }\r\n        \r\n        public static T? GetQueryParamNullable<T>(string paramName, IQueryCollection query, ParseDelegate<T> parse)\r\n            where T : struct\r\n        {\r\n            var strVal = query[paramName];\r\n            if (string.IsNullOrEmpty(strVal))\r\n            {\r\n                return null;\r\n            }\r\n\r\n            if (!parse(strVal, out T parsed))\r\n            {\r\n                throw new FormatException($\"Parameter '{paramName}' could not be parsed as a {typeof(T).Name}.\");\r\n            }\r\n\r\n            return parsed;\r\n        }\r\n        \r\n        public delegate bool ParseDelegate<T>(string strVal, out T parsed);\r\n    }\r\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
}
