using EfCoreTestSuite.CosmosDb.IntentGenerated.Core;
using EfCoreTestSuite.CosmosDb.IntentGenerated.Entities.NestedAssociations;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace EfCoreTestSuite.CosmosDb.IntegrationTests;

[Collection(CollectionFixture.CollectionDefinitionName)]
public class NestedAssociationTests
{
    private readonly DataContainerFixture _fixture;

    public NestedAssociationTests(DataContainerFixture fixture)
    {
        _fixture = fixture;
    }

    private ApplicationDbContext DbContext => _fixture.DbContext;
    
    [IgnoreOnCiBuildFact]
    public void Test_N_NestedOwnedEntity_Associations()
    {
        var rootOwner = new N_NestedOwnedAssocationOwner();
        rootOwner.PartitionKey = "ABC";
        rootOwner.OwnerAttr = "Root Owner Value" + Guid.NewGuid();
        DbContext.N_NestedOwnedAssocationOwners.Add(rootOwner);

        var owned = new N_OwnedEntity();
        owned.OwnedAttr = "Owned Value" + Guid.NewGuid();
        rootOwner.N_OwnedEntities.Add(owned);

        // Until many-to-many gets supported, this is commented out
        
        //var associationA = new N_OwnedEntityAssociationA();
        //associationA.AssociationAttr = "A" + Guid.NewGuid();
        //DbContext.N_OwnedEntityAssociationAs.Add(associationA);
        //owned.N_OwnedEntityAssociationAS.Add(associationA);
        
        var associationB = new N_OwnedEntityAssociationB();
        associationB.PartitionKey = "ABC";
        associationB.AssociationAttr = "B" + Guid.NewGuid();
        DbContext.N_OwnedEntityAssociationBs.Add(associationB);
        owned.N_OwnedEntityAssociationB = associationB;
        
        var associationC = new N_OwnedEntityAssociationC();
        associationC.AssociationAttr = "C" + Guid.NewGuid();
        owned.N_OwnedEntityAssociationCS.Add(associationC);

        var associationD = new N_OwnedEntityAssociationD();
        associationD.AssociationAttr = "D" + Guid.NewGuid();
        owned.N_OwnedEntityAssociationD = associationD;
        
        DbContext.SaveChanges();

        var retrievedRootOwner = DbContext.N_NestedOwnedAssocationOwners.Single(p => p.Id == rootOwner.Id);
        Assert.Equal(rootOwner.OwnerAttr, retrievedRootOwner.OwnerAttr);

        var retrievedOwned = retrievedRootOwner.N_OwnedEntities.Single(p => p.Id == owned.Id);
        Assert.Equal(retrievedOwned.OwnedAttr, owned.OwnedAttr);

        //Assert.Equal(associationA.AssociationAttr, retrievedOwned.N_OwnedEntityAssociationAS.Single().AssociationAttr);
        Assert.Equal(associationB.AssociationAttr, retrievedOwned.N_OwnedEntityAssociationB.AssociationAttr);
        Assert.Equal(associationC.AssociationAttr, retrievedOwned.N_OwnedEntityAssociationCS.Single().AssociationAttr);
        Assert.Equal(associationD.AssociationAttr, retrievedOwned.N_OwnedEntityAssociationD.AssociationAttr);
    }
}