using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EntityFrameworkCore.CosmosDb.TestApplication.Domain.Entities.Associations;
using EntityFrameworkCore.CosmosDb.TestApplication.Domain.Repositories.Associations;
using EntityFrameworkCore.CosmosDb.TestApplication.Infrastructure.Persistence;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.Repositories.Repository", Version = "1.0")]

namespace EntityFrameworkCore.CosmosDb.TestApplication.Infrastructure.Repositories.Associations
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class M_SelfReferenceBiNavRepository : RepositoryBase<M_SelfReferenceBiNav, M_SelfReferenceBiNav, ApplicationDbContext>, IM_SelfReferenceBiNavRepository
    {
        public M_SelfReferenceBiNavRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<M_SelfReferenceBiNav> FindByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await FindAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<List<M_SelfReferenceBiNav>> FindByIdsAsync(Guid[] ids, CancellationToken cancellationToken = default)
        {
            return await FindAllAsync(x => ids.Contains(x.Id), cancellationToken);
        }
    }
}