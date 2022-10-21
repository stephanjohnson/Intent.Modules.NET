using System;
using EfCoreTestSuite.CosmosDb.IntentGenerated.Entities.InheritanceAssociations;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace EfCoreTestSuite.CosmosDb.IntentGenerated.Core
{
    public class DerivedClassForConcreteConfiguration : IEntityTypeConfiguration<DerivedClassForConcrete>
    {
        public void Configure(EntityTypeBuilder<DerivedClassForConcrete> builder)
        {
            builder.HasBaseType<ConcreteBaseClass>();

            builder.Property(x => x.DerivedAttribute)
                .IsRequired()
                .HasMaxLength(250);
            builder.HasPartitionKey(x => x.PartitionKey);

            builder.Property(x => x.PartitionKey)
                .IsRequired();
        }
    }
}