using System;
using EfCoreTestSuite.IntentGenerated.Entities;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace EfCoreTestSuite.IntentGenerated.Core
{
    public class C_MultipleDependentConfiguration : IEntityTypeConfiguration<C_MultipleDependent>
    {
        public void Configure(EntityTypeBuilder<C_MultipleDependent> builder)
        {
            builder.HasKey(x => x.Id);


        }
    }
}