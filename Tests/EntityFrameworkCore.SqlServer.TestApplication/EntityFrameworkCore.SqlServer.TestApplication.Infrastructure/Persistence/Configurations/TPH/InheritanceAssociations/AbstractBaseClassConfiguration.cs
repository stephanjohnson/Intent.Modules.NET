using EntityFrameworkCore.SqlServer.TestApplication.Domain.Entities.TPH.InheritanceAssociations;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace EntityFrameworkCore.SqlServer.TestApplication.Infrastructure.Persistence.Configurations.TPH.InheritanceAssociations
{
    public class AbstractBaseClassConfiguration : IEntityTypeConfiguration<AbstractBaseClass>
    {
        public void Configure(EntityTypeBuilder<AbstractBaseClass> builder)
        {
            builder.ToTable("TphAbstractBaseClass");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.BaseAttribute)
                .IsRequired()
                .HasMaxLength(250);

            builder.Ignore(e => e.DomainEvents);
        }
    }
}