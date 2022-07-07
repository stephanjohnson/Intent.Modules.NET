﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.AzureFunctions.Interop.EntityFrameworkCore.Templates.DbInitializationService
{
    using System.Collections.Generic;
    using System.Linq;
    using Intent.Modules.Common;
    using Intent.Modules.Common.Templates;
    using Intent.Modules.Common.CSharp.Templates;
    using Intent.Templates;
    using Intent.Metadata.Models;
    using Intent.Modules.EntityFrameworkCore.Templates;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.AzureFunctions.Interop.EntityFrameworkCore\Templates\DbInitializationService\DbInitializationServiceTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class DbInitializationServiceTemplate : CSharpTemplateBase<object>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("using Microsoft.Azure.WebJobs;\r\nusing Microsoft.Azure.WebJobs.Description;\r\nusing Microsoft.Azure.WebJobs.Host.Config;\r\nusing Microsoft.Azure.WebJobs.Hosting;\r\nusing Microsoft.Extensions.DependencyInjection;\r\n\r\n[assembly: WebJobsStartup(typeof(");
            
            #line 17 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.AzureFunctions.Interop.EntityFrameworkCore\Templates\DbInitializationService\DbInitializationServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 17 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.AzureFunctions.Interop.EntityFrameworkCore\Templates\DbInitializationService\DbInitializationServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("), \"DbSeeder\")]\r\n\r\n[assembly: DefaultIntentManaged(Mode.Fully)]\r\n\r\nnamespace ");
            
            #line 21 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.AzureFunctions.Interop.EntityFrameworkCore\Templates\DbInitializationService\DbInitializationServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    public class ");
            
            #line 23 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.AzureFunctions.Interop.EntityFrameworkCore\Templates\DbInitializationService\DbInitializationServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(" : IWebJobsStartup\r\n    {\r\n        public void Configure(IWebJobsBuilder builder)\r\n        {\r\n            builder.AddExtension<DbSeedConfigProvider>();\r\n        }\r\n    }\r\n\r\n    [Extension(\"DbSeed\")]\r\n    internal class DbSeedConfigProvider : IExtensionConfigProvider\r\n    {\r\n        private readonly IServiceScopeFactory _scopeFactory;\r\n\r\n        public DbSeedConfigProvider(IServiceScopeFactory scopeFactory)\r\n        {\r\n            _scopeFactory = scopeFactory;\r\n        }\r\n\r\n        public void Initialize(ExtensionConfigContext context)\r\n        {\r\n            using var scope = _scopeFactory.CreateScope();\r\n            var dbContext = scope.ServiceProvider.GetService<");
            
            #line 44 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.AzureFunctions.Interop.EntityFrameworkCore\Templates\DbInitializationService\DbInitializationServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.GetDbContextName()));
            
            #line default
            #line hidden
            this.Write(">();\r\n\r\n            dbContext.Database.EnsureCreated();\r\n            // Further DB seeding, etc.\r\n        }\r\n    }\r\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
}