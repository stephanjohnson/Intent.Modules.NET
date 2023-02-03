using System;
using EfCoreTestSuite.IntentGenerated.Entities;
using EfCoreTestSuite.IntentGenerated.Entities.Associations;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace EfCoreTestSuite.IntentGenerated.Core.Associations
{
    public class E2_RequiredCompositeNavConfiguration : IEntityTypeConfiguration<E2_RequiredCompositeNav>
    {
        public void Configure(EntityTypeBuilder<E2_RequiredCompositeNav> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ReqCompNavAttr)
                .IsRequired();

            builder.OwnsOne(x => x.E2RequiredDependent, ConfigureE2RequiredDependent)
                .Navigation(x => x.E2RequiredDependent).IsRequired();
        }

        public void ConfigureE2RequiredDependent(OwnedNavigationBuilder<E2_RequiredCompositeNav, E2_RequiredDependent> builder)
        {
            builder.WithOwner(x => x.E2RequiredCompositeNav)
                .HasForeignKey(x => x.Id);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ReqDepAttr)
                .IsRequired();
        }
    }
}