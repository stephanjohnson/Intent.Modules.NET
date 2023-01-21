using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.DomainEntityInterface", Version = "1.0")]

namespace EfCoreTestSuite.CosmosDb.IntentGenerated.Entities.Associations
{
    public interface IJ_MultipleAggregate
    {

        string PartitionKey { get; set; }

        string MultipleAggrAttr { get; set; }

        IJ_RequiredDependent JRequiredDependent { get; set; }
    }
}