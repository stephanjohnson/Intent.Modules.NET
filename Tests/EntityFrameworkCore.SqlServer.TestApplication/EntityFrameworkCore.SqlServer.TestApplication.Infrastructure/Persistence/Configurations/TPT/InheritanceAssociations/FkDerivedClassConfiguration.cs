using EntityFrameworkCore.SqlServer.TestApplication.Domain.Entities.TPT.InheritanceAssociations;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace EntityFrameworkCore.SqlServer.TestApplication.Infrastructure.Persistence.Configurations.TPT.InheritanceAssociations
{
    public class FkDerivedClassConfiguration : IEntityTypeConfiguration<FkDerivedClass>
    {
        public void Configure(EntityTypeBuilder<FkDerivedClass> builder)
        {
            builder.ToTable("TptFkDerivedClass");

            builder.Property(x => x.DerivedField)
                .IsRequired();
        }
    }
}