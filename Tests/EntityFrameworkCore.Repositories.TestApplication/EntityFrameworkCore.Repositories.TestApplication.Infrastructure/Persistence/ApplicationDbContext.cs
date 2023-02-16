using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EntityFrameworkCore.Repositories.TestApplication.Application.Common.Interfaces;
using EntityFrameworkCore.Repositories.TestApplication.Domain.Common;
using EntityFrameworkCore.Repositories.TestApplication.Domain.Common.Interfaces;
using EntityFrameworkCore.Repositories.TestApplication.Domain.Entities;
using EntityFrameworkCore.Repositories.TestApplication.Infrastructure.Persistence.Configurations;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.DbContext", Version = "1.0")]

namespace EntityFrameworkCore.Repositories.TestApplication.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IUnitOfWork
    {
        private readonly IDomainEventService _domainEventService;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDomainEventService domainEventService) : base(options)
        {
            _domainEventService = domainEventService;
        }

        public DbSet<AggregateRoot1> AggregateRoot1s { get; set; }
        public DbSet<AggregateRoot2Composition> AggregateRoot2Compositions { get; set; }
        public DbSet<AggregateRoot3AggCollection> AggregateRoot3AggCollections { get; set; }
        public DbSet<AggregateRoot3Collection> AggregateRoot3Collections { get; set; }
        public DbSet<AggregateRoot3Nullable> AggregateRoot3Nullables { get; set; }
        public DbSet<AggregateRoot3Single> AggregateRoot3Singles { get; set; }
        public DbSet<AggregateRoot4AggNullable> AggregateRoot4AggNullables { get; set; }
        public DbSet<AggregateRoot4Collection> AggregateRoot4Collections { get; set; }
        public DbSet<AggregateRoot4Nullable> AggregateRoot4Nullables { get; set; }
        public DbSet<AggregateRoot4Single> AggregateRoot4Singles { get; set; }
        public DbSet<AggregateRoot5> AggregateRoot5s { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await DispatchEvents();
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ConfigureModel(modelBuilder);
            modelBuilder.ApplyConfiguration(new AggregateRoot1Configuration());
            modelBuilder.ApplyConfiguration(new AggregateRoot2CompositionConfiguration());
            modelBuilder.ApplyConfiguration(new AggregateRoot3AggCollectionConfiguration());
            modelBuilder.ApplyConfiguration(new AggregateRoot3CollectionConfiguration());
            modelBuilder.ApplyConfiguration(new AggregateRoot3NullableConfiguration());
            modelBuilder.ApplyConfiguration(new AggregateRoot3SingleConfiguration());
            modelBuilder.ApplyConfiguration(new AggregateRoot4AggNullableConfiguration());
            modelBuilder.ApplyConfiguration(new AggregateRoot4CollectionConfiguration());
            modelBuilder.ApplyConfiguration(new AggregateRoot4NullableConfiguration());
            modelBuilder.ApplyConfiguration(new AggregateRoot4SingleConfiguration());
            modelBuilder.ApplyConfiguration(new AggregateRoot5Configuration());
        }

        [IntentManaged(Mode.Ignore)]
        private void ConfigureModel(ModelBuilder modelBuilder)
        {
            // Seed data
            // https://rehansaeed.com/migrating-to-entity-framework-core-seed-data/
            /* Eg.
            
            modelBuilder.Entity<Car>().HasData(
            new Car() { CarId = 1, Make = "Ferrari", Model = "F40" },
            new Car() { CarId = 2, Make = "Ferrari", Model = "F50" },
            new Car() { CarId = 3, Make = "Labourghini", Model = "Countach" });
            */
        }

        private async Task DispatchEvents()
        {
            while (true)
            {
                var domainEventEntity = ChangeTracker
                    .Entries<IHasDomainEvent>()
                    .Select(x => x.Entity.DomainEvents)
                    .SelectMany(x => x)
                    .FirstOrDefault(domainEvent => !domainEvent.IsPublished);

                if (domainEventEntity == null) break;

                domainEventEntity.IsPublished = true;
                await _domainEventService.Publish(domainEventEntity);
            }
        }
    }
}