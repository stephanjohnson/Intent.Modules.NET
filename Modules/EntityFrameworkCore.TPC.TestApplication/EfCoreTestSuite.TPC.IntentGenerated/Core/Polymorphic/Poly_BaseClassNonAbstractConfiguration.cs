using System;
using EfCoreTestSuite.TPC.IntentGenerated.Entities;
using EfCoreTestSuite.TPC.IntentGenerated.Entities.Polymorphic;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace EfCoreTestSuite.TPC.IntentGenerated.Core.Polymorphic
{
    public class Poly_BaseClassNonAbstractConfiguration : IEntityTypeConfiguration<Poly_BaseClassNonAbstract>
    {
        public void Configure(EntityTypeBuilder<Poly_BaseClassNonAbstract> builder)
        {
            builder.ToTable("Poly_BaseClassNonAbstracts");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.AbstractField)
                .IsRequired();

            builder.Property(x => x.BaseField)
                .IsRequired();

            builder.HasOne(x => x.PolyRootAbstractAggr)
                .WithMany()
                .HasForeignKey(x => x.PolyRootAbstractAggrId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.OwnsOne(x => x.PolyRootAbstractComp, ConfigurePolyRootAbstractComp);

            builder.Ignore(e => e.DomainEvents);
        }

        public void ConfigurePolyRootAbstractComp(OwnedNavigationBuilder<Poly_BaseClassNonAbstract, Poly_RootAbstract_Comp> builder)
        {
            builder.WithOwner()
                .HasForeignKey(x => x.Id);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.CompField)
                .IsRequired();
        }
    }
}