using System;
using EfCoreTestSuite.CosmosDb.IntentGenerated.Entities.InheritanceAssociations;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace EfCoreTestSuite.CosmosDb.IntentGenerated.Core
{
    public class ConcreteBaseClassAssociatedConfiguration : IEntityTypeConfiguration<ConcreteBaseClassAssociated>
    {
        public void Configure(EntityTypeBuilder<ConcreteBaseClassAssociated> builder)
        {
            builder.ToContainer("EntityFrameworkCore.CosmosDb.TestApplication");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.AssociatedField)
                .IsRequired();

            builder.Property(x => x.PartitionKey)
                .IsRequired();
            builder.HasPartitionKey(x => x.PartitionKey);

            builder.HasOne(x => x.ConcreteBaseClass)
                .WithMany()
                .HasForeignKey(x => new { x.PartitionKey, x.ConcreteBaseClassId })
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}