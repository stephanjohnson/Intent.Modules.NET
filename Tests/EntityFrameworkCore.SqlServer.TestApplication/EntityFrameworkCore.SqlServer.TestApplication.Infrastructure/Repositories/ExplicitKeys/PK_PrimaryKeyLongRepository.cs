using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EntityFrameworkCore.SqlServer.TestApplication.Domain.Entities.ExplicitKeys;
using EntityFrameworkCore.SqlServer.TestApplication.Domain.Repositories.ExplicitKeys;
using EntityFrameworkCore.SqlServer.TestApplication.Infrastructure.Persistence;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.Repositories.Repository", Version = "1.0")]

namespace EntityFrameworkCore.SqlServer.TestApplication.Infrastructure.Repositories.ExplicitKeys
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class PK_PrimaryKeyLongRepository : RepositoryBase<PK_PrimaryKeyLong, PK_PrimaryKeyLong, ApplicationDbContext>, IPK_PrimaryKeyLongRepository
    {
        public PK_PrimaryKeyLongRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<PK_PrimaryKeyLong> FindByIdAsync(long primaryKeyLong, CancellationToken cancellationToken = default)
        {
            return await FindAsync(x => x.PrimaryKeyLong == primaryKeyLong, cancellationToken);
        }

        public async Task<List<PK_PrimaryKeyLong>> FindByIdsAsync(long[] primaryKeyLongs, CancellationToken cancellationToken = default)
        {
            return await FindAllAsync(x => primaryKeyLongs.Contains(x.PrimaryKeyLong), cancellationToken);
        }
    }
}