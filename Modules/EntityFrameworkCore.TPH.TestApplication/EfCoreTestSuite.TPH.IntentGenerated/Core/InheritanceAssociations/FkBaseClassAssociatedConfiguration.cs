using System;
using EfCoreTestSuite.TPH.IntentGenerated.Entities;
using EfCoreTestSuite.TPH.IntentGenerated.Entities.InheritanceAssociations;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace EfCoreTestSuite.TPH.IntentGenerated.Core.InheritanceAssociations
{
    public class FkBaseClassAssociatedConfiguration : IEntityTypeConfiguration<FkBaseClassAssociated>
    {
        public void Configure(EntityTypeBuilder<FkBaseClassAssociated> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.AssociatedField)
                .IsRequired();

            builder.HasOne(x => x.FkBaseClass)
                .WithMany()
                .HasForeignKey(x => new { x.FkBaseClassCompositeKeyA, x.FkBaseClassCompositeKeyB })
                .OnDelete(DeleteBehavior.Restrict);

            builder.Ignore(e => e.DomainEvents);
        }
    }
}