// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.AspNetCore.Swashbuckle.Templates.SwashbuckleConfiguration
{
    using System.Collections.Generic;
    using System.Linq;
    using Intent.Modules.Common;
    using Intent.Modules.Common.Templates;
    using Intent.Modules.Common.CSharp.Templates;
    using Intent.Templates;
    using Intent.Metadata.Models;
    using Intent.Modules.AspNetCore.Swashbuckle.Templates.AuthorizeCheckOperationFilter;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.AspNetCore.Swashbuckle\Templates\SwashbuckleConfiguration\SwashbuckleConfigurationTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class SwashbuckleConfigurationTemplate : CSharpTemplateBase<object>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write(@"using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

[assembly: DefaultIntentManaged(Mode.Fully)]

namespace ");
            
            #line 19 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.AspNetCore.Swashbuckle\Templates\SwashbuckleConfiguration\SwashbuckleConfigurationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    public static class ");
            
            #line 21 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.AspNetCore.Swashbuckle\Templates\SwashbuckleConfiguration\SwashbuckleConfigurationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("\r\n    {\r\n        public static IServiceCollection ConfigureSwagger(this IServiceC" +
                    "ollection services, IConfiguration configuration)\r\n        {\r\n            servic" +
                    "es.AddSwaggerGen(c => c.OperationFilter<");
            
            #line 25 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.AspNetCore.Swashbuckle\Templates\SwashbuckleConfiguration\SwashbuckleConfigurationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetTypeName(AuthorizeCheckOperationFilterTemplate.TemplateId)));
            
            #line default
            #line hidden
            this.Write(@">());
            services.Configure<SwaggerGenOptions>(configuration.GetSection(""Swashbuckle:SwaggerGen""));
            services.Configure<SwaggerOptions>(configuration.GetSection(""Swashbuckle:Swagger""));
            services.Configure<SwaggerUIOptions>(configuration.GetSection(""Swashbuckle:SwaggerUI""));
            return services;
        }
    }
}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
