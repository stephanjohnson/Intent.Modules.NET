using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EntityFrameworkCore.SqlServer.TestApplication.Domain.Entities.Associations;
using EntityFrameworkCore.SqlServer.TestApplication.Domain.Repositories.Associations;
using EntityFrameworkCore.SqlServer.TestApplication.Infrastructure.Persistence;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.Repositories.Repository", Version = "1.0")]

namespace EntityFrameworkCore.SqlServer.TestApplication.Infrastructure.Repositories.Associations
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class L_SelfReferenceMultipleRepository : RepositoryBase<L_SelfReferenceMultiple, L_SelfReferenceMultiple, ApplicationDbContext>, IL_SelfReferenceMultipleRepository
    {
        public L_SelfReferenceMultipleRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<L_SelfReferenceMultiple> FindByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await FindAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<List<L_SelfReferenceMultiple>> FindByIdsAsync(Guid[] ids, CancellationToken cancellationToken = default)
        {
            return await FindAllAsync(x => ids.Contains(x.Id), cancellationToken);
        }
    }
}