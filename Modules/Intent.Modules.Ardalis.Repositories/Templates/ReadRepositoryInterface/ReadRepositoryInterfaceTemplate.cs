﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.Ardalis.Repositories.Templates.ReadRepositoryInterface
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
    
    #line 1 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Ardalis.Repositories\Templates\ReadRepositoryInterface\ReadRepositoryInterfaceTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class ReadRepositoryInterfaceTemplate : CSharpTemplateBase<Intent.Modelers.Domain.Api.ClassModel>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("using System;\r\nusing System.Collections.Generic;\r\nusing System.Linq;\r\nusing System.Linq.Expressions;\r\nusing System.Threading;\r\nusing System.Threading.Tasks;\r\nusing Ardalis.Specification;\r\n\r\n[assembly: DefaultIntentManaged(Mode.Fully)]\r\n\r\nnamespace ");
            
            #line 20 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Ardalis.Repositories\Templates\ReadRepositoryInterface\ReadRepositoryInterfaceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]\r\n    public interface ");
            
            #line 23 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Ardalis.Repositories\Templates\ReadRepositoryInterface\ReadRepositoryInterfaceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(" : IReadRepositoryBase<");
            
            #line 23 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Ardalis.Repositories\Templates\ReadRepositoryInterface\ReadRepositoryInterfaceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetPersistenceEntityTypeName()));
            
            #line default
            #line hidden
            this.Write(">\r\n    {\r\n");
            
            #line 25 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Ardalis.Repositories\Templates\ReadRepositoryInterface\ReadRepositoryInterfaceTemplate.tt"

    if (HasSinglePrimaryKey())
    {

            
            #line default
            #line hidden
            this.Write("        [IntentManaged(Mode.Fully)]\r\n        Task<");
            
            #line 30 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Ardalis.Repositories\Templates\ReadRepositoryInterface\ReadRepositoryInterfaceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetDomainEntityTypeName()));
            
            #line default
            #line hidden
            this.Write("?> FindByIdAsync(");
            
            #line 30 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Ardalis.Repositories\Templates\ReadRepositoryInterface\ReadRepositoryInterfaceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetSurrogateKey()));
            
            #line default
            #line hidden
            this.Write(" id, CancellationToken cancellationToken = default);\r\n\r\n        [IntentManaged(Mode.Fully)]\r\n        Task<List<");
            
            #line 33 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Ardalis.Repositories\Templates\ReadRepositoryInterface\ReadRepositoryInterfaceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetDomainEntityTypeName()));
            
            #line default
            #line hidden
            this.Write(">> FindByIdsAsync(");
            
            #line 33 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Ardalis.Repositories\Templates\ReadRepositoryInterface\ReadRepositoryInterfaceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetSurrogateKey()));
            
            #line default
            #line hidden
            this.Write("[] ids, CancellationToken cancellationToken = default);\r\n");
            
            #line 34 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Ardalis.Repositories\Templates\ReadRepositoryInterface\ReadRepositoryInterfaceTemplate.tt"

    } 

            
            #line default
            #line hidden
            this.Write("        [IntentManaged(Mode.Fully)]\r\n        Task<IPagedResult<");
            
            #line 38 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Ardalis.Repositories\Templates\ReadRepositoryInterface\ReadRepositoryInterfaceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetDomainEntityTypeName()));
            
            #line default
            #line hidden
            this.Write(">> FindAllAsync(int pageNo, int pageSize, CancellationToken cancellationToken = default);\r\n\r\n        [IntentManaged(Mode.Fully)]\r\n        Task<IPagedResult<");
            
            #line 41 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Ardalis.Repositories\Templates\ReadRepositoryInterface\ReadRepositoryInterfaceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetDomainEntityTypeName()));
            
            #line default
            #line hidden
            this.Write(">> FindAllAsync(Expression<Func<");
            
            #line 41 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Ardalis.Repositories\Templates\ReadRepositoryInterface\ReadRepositoryInterfaceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetPersistenceEntityTypeName()));
            
            #line default
            #line hidden
            this.Write(", bool>> filterExpression, int pageNo, int pageSize, CancellationToken cancellationToken = default);\r\n\r\n        [IntentManaged(Mode.Fully)]\r\n        Task<IPagedResult<");
            
            #line 44 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Ardalis.Repositories\Templates\ReadRepositoryInterface\ReadRepositoryInterfaceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetDomainEntityTypeName()));
            
            #line default
            #line hidden
            this.Write(">> FindAllAsync(Expression<Func<");
            
            #line 44 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Ardalis.Repositories\Templates\ReadRepositoryInterface\ReadRepositoryInterfaceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetPersistenceEntityTypeName()));
            
            #line default
            #line hidden
            this.Write(", bool>> filterExpression, int pageNo, int pageSize, Func<IQueryable<");
            
            #line 44 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Ardalis.Repositories\Templates\ReadRepositoryInterface\ReadRepositoryInterfaceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetPersistenceEntityTypeName()));
            
            #line default
            #line hidden
            this.Write(">, IQueryable<");
            
            #line 44 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Ardalis.Repositories\Templates\ReadRepositoryInterface\ReadRepositoryInterfaceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetPersistenceEntityTypeName()));
            
            #line default
            #line hidden
            this.Write(">> linq, CancellationToken cancellationToken = default);\r\n    }\r\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
}