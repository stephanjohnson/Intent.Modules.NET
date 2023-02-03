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
    public class A_RequiredCompositeConfiguration : IEntityTypeConfiguration<A_RequiredComposite>
    {
        public void Configure(EntityTypeBuilder<A_RequiredComposite> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.RequiredCompAttr)
                .IsRequired();

            builder.OwnsOne(x => x.AOptionalDependent, ConfigureAOptionalDependent);
        }

        public void ConfigureAOptionalDependent(OwnedNavigationBuilder<A_RequiredComposite, A_OptionalDependent> builder)
        {
            builder.WithOwner()
                .HasForeignKey(x => x.Id);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.OptionalDepAttr)
                .IsRequired();
        }
    }
}