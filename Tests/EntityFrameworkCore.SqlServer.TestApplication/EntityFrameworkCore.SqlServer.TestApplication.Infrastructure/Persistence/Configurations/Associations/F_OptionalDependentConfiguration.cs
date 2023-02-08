using EntityFrameworkCore.SqlServer.TestApplication.Domain.Entities.Associations;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace EntityFrameworkCore.SqlServer.TestApplication.Infrastructure.Persistence.Configurations.Associations
{
    public class F_OptionalDependentConfiguration : IEntityTypeConfiguration<F_OptionalDependent>
    {
        public void Configure(EntityTypeBuilder<F_OptionalDependent> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.OptionalDepAttr)
                .IsRequired();

            builder.Ignore(e => e.DomainEvents);
        }
    }
}