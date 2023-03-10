using System.Collections.Generic;
using System.Linq;
using Intent.CosmosDb.Api;
using Intent.Metadata.Models;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.ModuleBuilder.Templates.Api.ApiMetadataPackageExtensions", Version = "1.0")]

namespace Intent.CosmosDb.Api
{
    public static class ApiMetadataPackageExtensions
    {
        public static IList<CosmosDbDomainPackageModel> GetCosmosDbDomainPackageModels(this IDesigner designer)
        {
            return designer.GetPackagesOfType(CosmosDbDomainPackageModel.SpecializationTypeId)
                .Select(x => new CosmosDbDomainPackageModel(x))
                .ToList();
        }

        public static bool IsCosmosDbDomainPackageModel(this IPackage package)
        {
            return package?.SpecializationTypeId == CosmosDbDomainPackageModel.SpecializationTypeId;
        }
    }
}