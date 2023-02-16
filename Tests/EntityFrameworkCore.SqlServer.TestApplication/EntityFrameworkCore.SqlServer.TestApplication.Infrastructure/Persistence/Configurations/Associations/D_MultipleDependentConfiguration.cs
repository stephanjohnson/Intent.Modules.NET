using EntityFrameworkCore.SqlServer.TestApplication.Domain.Entities.Associations;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace EntityFrameworkCore.SqlServer.TestApplication.Infrastructure.Persistence.Configurations.Associations
{
    public class D_MultipleDependentConfiguration : IEntityTypeConfiguration<D_MultipleDependent>
    {
        public void Configure(EntityTypeBuilder<D_MultipleDependent> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.MultipleDepAttr)
                .IsRequired();

            builder.Ignore(e => e.DomainEvents);
        }
    }
}