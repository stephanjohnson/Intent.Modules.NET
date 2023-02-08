using EntityFrameworkCore.CosmosDb.TestApplication.Domain.Entities;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace EntityFrameworkCore.CosmosDb.TestApplication.Infrastructure.Persistence.Configurations
{
    public class ExplicitKeyClassConfiguration : IEntityTypeConfiguration<ExplicitKeyClass>
    {
        public void Configure(EntityTypeBuilder<ExplicitKeyClass> builder)
        {
            builder.ToContainer("PartitionKeyDefaullt");

            builder.HasPartitionKey(x => x.Id);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Attribute)
                .IsRequired();

            builder.Ignore(e => e.DomainEvents);
        }
    }
}