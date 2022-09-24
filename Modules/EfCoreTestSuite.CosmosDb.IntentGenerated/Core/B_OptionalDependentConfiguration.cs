using System;
using EfCoreTestSuite.CosmosDb.IntentGenerated.Entities.Associations;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace EfCoreTestSuite.CosmosDb.IntentGenerated.Core
{
    public class B_OptionalDependentConfiguration : IEntityTypeConfiguration<B_OptionalDependent>
    {
        public void Configure(EntityTypeBuilder<B_OptionalDependent> builder)
        {
            builder.ToTable("B_OptionalDependent");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.OptionalDependentAttr)
                .IsRequired();

            builder.Property(x => x.PartitionKey)
                .IsRequired();
            builder.HasPartitionKey(x => x.PartitionKey);

        }
    }
}