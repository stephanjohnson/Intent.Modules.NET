using System;
using EfCoreTestSuite.TPC.IntentGenerated.Entities;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace EfCoreTestSuite.TPC.IntentGenerated.Core
{
    public class FkAssociatedClassConfiguration : IEntityTypeConfiguration<FkAssociatedClass>
    {
        public void Configure(EntityTypeBuilder<FkAssociatedClass> builder)
        {
            builder.ToTable("FkAssociatedClass");

            builder.HasKey(x => x.Id);


            builder.HasOne(x => x.FkDerivedClass)
                .WithMany()
                .HasForeignKey(x => new { x.FkDerivedClassCompositeKeyA, x.FkDerivedClassCompositeKeyB })
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}