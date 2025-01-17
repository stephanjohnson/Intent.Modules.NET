// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 17.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.Application.MediatR.Behaviours.Templates.UnitOfWorkBehaviour
{
    using System.Collections.Generic;
    using System.Linq;
    using Intent.Modules.Common;
    using Intent.Modules.Common.Templates;
    using Intent.Modules.Common.CSharp.Templates;
    using Intent.Templates;
    using Intent.Metadata.Models;
    using Intent.Modules.Application.MediatR.Templates;
    using Intent.Modules.Constants;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Application.MediatR.Behaviours\Templates\UnitOfWorkBehaviour\UnitOfWorkBehaviourTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class UnitOfWorkBehaviourTemplate : CSharpTemplateBase<object>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("using System.Threading;\r\nusing System.Threading.Tasks;\r\nusing System.Transactions" +
                    ";\r\nusing MediatR;\r\n\r\n[assembly: DefaultIntentManaged(Mode.Fully)]\r\n\r\nnamespace ");
            
            #line 19 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Application.MediatR.Behaviours\Templates\UnitOfWorkBehaviour\UnitOfWorkBehaviourTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write(@"
{
    /// <summary>
    /// Ensures that all operations processed as part of handling a <see cref=""ICommand""/> either
    /// pass or fail as one unit. This behaviour makes it unnecessary for developers to call
    /// SaveChangesAsync() inside their business logic (e.g. command handlers), and doing so should
    /// be avoided unless absolutely necessary.
    /// </summary>
    public class ");
            
            #line 27 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Application.MediatR.Behaviours\Templates\UnitOfWorkBehaviour\UnitOfWorkBehaviourTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>\r\n        where TRe" +
                    "quest : IRequest<TResponse>, ");
            
            #line 28 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Application.MediatR.Behaviours\Templates\UnitOfWorkBehaviour\UnitOfWorkBehaviourTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.GetCommandInterfaceName()));
            
            #line default
            #line hidden
            this.Write("\r\n    {\r\n        private readonly ");
            
            #line 30 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Application.MediatR.Behaviours\Templates\UnitOfWorkBehaviour\UnitOfWorkBehaviourTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_unitOfWorkTypeName));
            
            #line default
            #line hidden
            this.Write(" _dataSource;\r\n\r\n        public ");
            
            #line 32 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Application.MediatR.Behaviours\Templates\UnitOfWorkBehaviour\UnitOfWorkBehaviourTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("(");
            
            #line 32 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Application.MediatR.Behaviours\Templates\UnitOfWorkBehaviour\UnitOfWorkBehaviourTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_unitOfWorkTypeName));
            
            #line default
            #line hidden
            this.Write(" dataSource)\r\n        {\r\n            _dataSource = dataSource;\r\n        }\r\n\r\n    " +
                    "    public async Task<TResponse> Handle(TRequest request, CancellationToken canc" +
                    "ellationToken, RequestHandlerDelegate<TResponse> next)\r\n        {\r\n            /" +
                    "/ The pipeline execution is wrapped in a transaction scope to ensure that if any" +
                    " other\r\n            // SaveChanges calls to the data source (e.g. EF Core) are c" +
                    "alled, that they are\r\n            // transacted atomically. The isolation is set" +
                    " to ReadCommitted by default (i.e. read-\r\n            // locks are released, whi" +
                    "le write-locks are maintained for the duration of the\r\n            // transactio" +
                    "n). Learn more on this approach for EF Core:\r\n            // https://docs.micros" +
                    "oft.com/en-us/ef/core/saving/transactions#using-systemtransactions\r\n            " +
                    "using (var transaction = new TransactionScope(TransactionScopeOption.Required, \r" +
                    "\n                new TransactionOptions() { IsolationLevel = IsolationLevel.Read" +
                    "Committed }, TransactionScopeAsyncFlowOption.Enabled))\r\n            {\r\n         " +
                    "       var response = await next();\r\n\r\n                // By calling SaveChanges" +
                    " at the last point in the transaction ensures that write-\r\n                // lo" +
                    "cks in the database are created and then released as quickly as possible. This\r\n" +
                    "                // helps optimize the application to handle a higher degree of c" +
                    "oncurrency.\r\n                await _dataSource.SaveChangesAsync(cancellationToke" +
                    "n);\r\n\r\n                // Commit transaction if all commands succeed, transactio" +
                    "n will auto-rollback when\r\n                // disposed if anything failed.\r\n    " +
                    "            transaction.Complete();\r\n                return response;\r\n         " +
                    "   }\r\n        }\r\n    }\r\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
