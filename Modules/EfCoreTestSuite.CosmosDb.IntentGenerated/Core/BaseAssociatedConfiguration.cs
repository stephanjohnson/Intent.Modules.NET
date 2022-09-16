using System;
using EfCoreTestSuite.CosmosDb.IntentGenerated.Entities;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace EfCoreTestSuite.CosmosDb.IntentGenerated.Core
{
    public class BaseAssociatedConfiguration : IEntityTypeConfiguration<BaseAssociated>
    {
        public void Configure(EntityTypeBuilder<BaseAssociated> builder)
        {
            builder.ToTable("BaseAssociated");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.PartitionKey)
                .IsRequired();

            builder.Property(x => x.BaseAssociatedField1)
                .IsRequired();
            builder.HasPartitionKey(x => x.PartitionKey);

        }
    }
}