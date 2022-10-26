using System;
using EfCoreTestSuite.CosmosDb.IntentGenerated.Entities.Associations;
using EfCoreTestSuite.CosmosDb.IntentGenerated.Entities.NestedAssociations;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace EfCoreTestSuite.CosmosDb.IntentGenerated.Core
{
    public class N_OwnedEntityAssociationBConfiguration : IEntityTypeConfiguration<N_OwnedEntityAssociationB>
    {
        public void Configure(EntityTypeBuilder<N_OwnedEntityAssociationB> builder)
        {
            builder.ToContainer("EntityFrameworkCore.CosmosDb.TestApplication");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.PartitionKey)
                .IsRequired();

            builder.Property(x => x.AssociationAttr)
                .IsRequired();
            builder.HasPartitionKey(x => x.PartitionKey);
        }
    }
}