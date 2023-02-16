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
    public class PK_A_CompositeKeyRepository : RepositoryBase<PK_A_CompositeKey, PK_A_CompositeKey, ApplicationDbContext>, IPK_A_CompositeKeyRepository
    {
        public PK_A_CompositeKeyRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}