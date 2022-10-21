using System;
using EfCoreTestSuite.IntentGenerated.Entities;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace EfCoreTestSuite.IntentGenerated.Core
{
    public class N_NestedOwnedAssocationOwnerConfiguration : IEntityTypeConfiguration<N_NestedOwnedAssocationOwner>
    {
        public void Configure(EntityTypeBuilder<N_NestedOwnedAssocationOwner> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.OwnerAttr)
                .IsRequired();

            builder.OwnsMany(x => x.N_OwnedEntities, ConfigureN_OwnedEntities);
        }

        public void ConfigureN_OwnedEntityAssociationCS(OwnedNavigationBuilder<N_OwnedEntity, N_OwnedEntityAssociationC> builder)
        {
            builder.WithOwner().HasForeignKey(x => x.N_OwnedEntityId);
            builder.HasKey(x => x.Id);

            builder.Property(x => x.AssociationAttr)
                .IsRequired();
        }

        public void ConfigureN_OwnedEntityAssociationD(OwnedNavigationBuilder<N_OwnedEntity, N_OwnedEntityAssociationD> builder)
        {
            builder.WithOwner().HasForeignKey(x => x.Id);
            builder.HasKey(x => x.Id);

            builder.Property(x => x.AssociationAttr)
                .IsRequired();
        }

        public void ConfigureN_OwnedEntities(OwnedNavigationBuilder<N_NestedOwnedAssocationOwner, N_OwnedEntity> builder)
        {
            builder.WithOwner(x => x.N_NestedOwnedAssocationOwner).HasForeignKey(x => x.N_NestedOwnedAssocationOwnerId);
            builder.HasKey(x => x.Id);

            builder.Property(x => x.OwnedAttr)
                .IsRequired();

            // builder.HasMany(x => x.N_OwnedEntityAssociationAS)
            //     .WithMany("N_OwnedEntities")
            //     .UsingEntity(x => x.ToTable("N_OwnedEntityN_OwnedEntityAssociationAs"));

            builder.HasOne(x => x.N_OwnedEntityAssociationB)
                .WithMany()
                .HasForeignKey(x => x.N_OwnedEntityAssociationBId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.OwnsMany(x => x.N_OwnedEntityAssociationCS, ConfigureN_OwnedEntityAssociationCS);

            builder.OwnsOne(x => x.N_OwnedEntityAssociationD, ConfigureN_OwnedEntityAssociationD)
                .Navigation(x => x.N_OwnedEntityAssociationD).IsRequired();
        }
    }
}