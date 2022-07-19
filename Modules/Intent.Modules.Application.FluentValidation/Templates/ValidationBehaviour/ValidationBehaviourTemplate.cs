﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.Application.FluentValidation.Templates.ValidationBehaviour
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
    
    #line 1 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Application.FluentValidation\Templates\ValidationBehaviour\ValidationBehaviourTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class ValidationBehaviourTemplate : CSharpTemplateBase<object, Intent.Modules.Application.FluentValidation.Templates.ValidationBehaviour.ValidationBehaviourContract>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("using System.Collections.Generic;\r\nusing System.Linq;\r\nusing System.Threading;\r\nusing System.Threading.Tasks;\r\nusing FluentValidation;\r\n\r\n[assembly: DefaultIntentManaged(Mode.Fully)]\r\n\r\nnamespace ");
            
            #line 18 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Application.FluentValidation\Templates\ValidationBehaviour\ValidationBehaviourTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    public class ");
            
            #line 20 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Application.FluentValidation\Templates\ValidationBehaviour\ValidationBehaviourTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            
            #line 20 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Application.FluentValidation\Templates\ValidationBehaviour\ValidationBehaviourTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetGenericTypeParameters()));
            
            #line default
            #line hidden
            
            #line 20 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Application.FluentValidation\Templates\ValidationBehaviour\ValidationBehaviourTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetInheritanceDeclarations()));
            
            #line default
            #line hidden
            
            #line 20 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Application.FluentValidation\Templates\ValidationBehaviour\ValidationBehaviourTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetGenericTypeConstraints()));
            
            #line default
            #line hidden
            this.Write("\r\n    {\r\n        private readonly IEnumerable<IValidator<TRequest>> _validators;\r\n\r\n        public ");
            
            #line 24 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Application.FluentValidation\Templates\ValidationBehaviour\ValidationBehaviourTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("(IEnumerable<IValidator<TRequest>> validators)\r\n        {\r\n            _validators = validators;\r\n        }\r\n\r\n        public async ");
            
            #line 29 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Application.FluentValidation\Templates\ValidationBehaviour\ValidationBehaviourTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetHandleReturnType()));
            
            #line default
            #line hidden
            this.Write(" Handle(");
            
            #line 29 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Application.FluentValidation\Templates\ValidationBehaviour\ValidationBehaviourTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetHandleParameterList()));
            
            #line default
            #line hidden
            this.Write(")\r\n        {\r\n            if (_validators.Any())\r\n            {\r\n                var context = new ValidationContext<TRequest>(request);\r\n\r\n                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));\r\n                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();\r\n\r\n                if (failures.Count != 0)\r\n                    throw new ");
            
            #line 39 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Application.FluentValidation\Templates\ValidationBehaviour\ValidationBehaviourTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetValidationException()));
            
            #line default
            #line hidden
            this.Write("(failures);\r\n            }\r\n            ");
            
            #line 41 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Application.FluentValidation\Templates\ValidationBehaviour\ValidationBehaviourTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetHandleExitStatementList()));
            
            #line default
            #line hidden
            this.Write("\r\n        }\r\n    }\r\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
}