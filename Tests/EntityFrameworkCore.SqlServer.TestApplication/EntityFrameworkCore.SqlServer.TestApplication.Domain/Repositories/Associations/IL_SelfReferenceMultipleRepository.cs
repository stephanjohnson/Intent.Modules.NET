using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EntityFrameworkCore.SqlServer.TestApplication.Domain.Entities.Associations;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.Repositories.Api.EntityRepositoryInterface", Version = "1.0")]

namespace EntityFrameworkCore.SqlServer.TestApplication.Domain.Repositories.Associations
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public interface IL_SelfReferenceMultipleRepository : IRepository<L_SelfReferenceMultiple, L_SelfReferenceMultiple>
    {

        [IntentManaged(Mode.Fully)]
        Task<L_SelfReferenceMultiple> FindByIdAsync(Guid id, CancellationToken cancellationToken = default);
        [IntentManaged(Mode.Fully)]
        Task<List<L_SelfReferenceMultiple>> FindByIdsAsync(Guid[] ids, CancellationToken cancellationToken = default);
    }
}