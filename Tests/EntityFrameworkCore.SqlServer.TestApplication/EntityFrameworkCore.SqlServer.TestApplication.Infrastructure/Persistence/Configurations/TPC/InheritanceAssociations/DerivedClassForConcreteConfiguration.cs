using EntityFrameworkCore.SqlServer.TestApplication.Domain.Entities.TPC.InheritanceAssociations;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace EntityFrameworkCore.SqlServer.TestApplication.Infrastructure.Persistence.Configurations.TPC.InheritanceAssociations
{
    public class DerivedClassForConcreteConfiguration : IEntityTypeConfiguration<DerivedClassForConcrete>
    {
        public void Configure(EntityTypeBuilder<DerivedClassForConcrete> builder)
        {
            builder.ToTable("TpcDerivedClassForConcrete");

            builder.Property(x => x.DerivedAttribute)
                .IsRequired()
                .HasMaxLength(250);
        }
    }
}