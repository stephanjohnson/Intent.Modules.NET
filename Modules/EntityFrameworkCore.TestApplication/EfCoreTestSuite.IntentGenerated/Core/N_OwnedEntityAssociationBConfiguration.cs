using System;
using EfCoreTestSuite.IntentGenerated.Entities;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace EfCoreTestSuite.IntentGenerated.Core
{
    public class N_OwnedEntityAssociationBConfiguration : IEntityTypeConfiguration<N_OwnedEntityAssociationB>
    {
        public void Configure(EntityTypeBuilder<N_OwnedEntityAssociationB> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.AssociationAttr)
                .IsRequired();
        }
    }
}