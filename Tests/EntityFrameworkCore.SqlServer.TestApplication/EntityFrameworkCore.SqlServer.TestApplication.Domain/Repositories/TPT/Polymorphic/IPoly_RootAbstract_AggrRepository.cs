using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EntityFrameworkCore.SqlServer.TestApplication.Domain.Entities.TPT.Polymorphic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.Repositories.Api.EntityRepositoryInterface", Version = "1.0")]

namespace EntityFrameworkCore.SqlServer.TestApplication.Domain.Repositories.TPT.Polymorphic
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public interface IPoly_RootAbstract_AggrRepository : IRepository<Poly_RootAbstract_Aggr, Poly_RootAbstract_Aggr>
    {

        [IntentManaged(Mode.Fully)]
        Task<Poly_RootAbstract_Aggr> FindByIdAsync(Guid id, CancellationToken cancellationToken = default);
        [IntentManaged(Mode.Fully)]
        Task<List<Poly_RootAbstract_Aggr>> FindByIdsAsync(Guid[] ids, CancellationToken cancellationToken = default);
    }
}