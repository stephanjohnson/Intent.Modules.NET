using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EntityFrameworkCore.Repositories.TestApplication.Domain.Entities;
using EntityFrameworkCore.Repositories.TestApplication.Domain.Repositories;
using EntityFrameworkCore.Repositories.TestApplication.Infrastructure.Persistence;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.Repositories.Repository", Version = "1.0")]

namespace EntityFrameworkCore.Repositories.TestApplication.Infrastructure.Repositories
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class AggregateRoot4SingleRepository : RepositoryBase<AggregateRoot4Single, AggregateRoot4Single, ApplicationDbContext>, IAggregateRoot4SingleRepository
    {
        public AggregateRoot4SingleRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<AggregateRoot4Single> FindByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await FindAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<List<AggregateRoot4Single>> FindByIdsAsync(Guid[] ids, CancellationToken cancellationToken = default)
        {
            return await FindAllAsync(x => ids.Contains(x.Id), cancellationToken);
        }
    }
}