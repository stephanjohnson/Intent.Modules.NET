﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.VisualStudio.Projects.Templates.ConsoleApp.Program
{
    using Intent.Modules.Common.Templates;
    using Intent.Modules.Common.CSharp.Templates;
    using System;
    using System.IO;
    using System.Diagnostics;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.VisualStudio.Projects\Templates\ConsoleApp\Program\ConsoleAppProgramTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class ConsoleAppProgramTemplate : CSharpTemplateBase<object>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write(" \r\n");
            this.Write(" \r\n");
            
            #line 14 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.VisualStudio.Projects\Templates\ConsoleApp\Program\ConsoleAppProgramTemplate.tt"




            
            #line default
            #line hidden
            this.Write("using System;\r\nusing System.Collections.Generic;\r\nusing System.IO;\r\nusing System." +
                    "Linq;\r\nusing System.Threading.Tasks;\r\n");
            
            #line 23 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.VisualStudio.Projects\Templates\ConsoleApp\Program\ConsoleAppProgramTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DependencyUsings));
            
            #line default
            #line hidden
            this.Write("\r\n\r\n[assembly: DefaultIntentManaged(Mode.Fully)]\r\n\r\nnamespace ");
            
            #line 27 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.VisualStudio.Projects\Templates\ConsoleApp\Program\ConsoleAppProgramTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    public class Program\r\n    {\r\n        [IntentManaged(Mode.Ignore)]\r\n     " +
                    "   public static void Main(string[] args)\r\n        {\r\n            Console.WriteL" +
                    "ine(\"Application Started...\");\r\n            Console.ReadLine();\r\n        }\r\n    " +
                    "}\r\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
