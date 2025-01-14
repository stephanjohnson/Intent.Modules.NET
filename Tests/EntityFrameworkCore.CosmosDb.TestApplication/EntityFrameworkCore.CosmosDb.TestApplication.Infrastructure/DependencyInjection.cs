using EntityFrameworkCore.CosmosDb.TestApplication.Application.Common.Interfaces;
using EntityFrameworkCore.CosmosDb.TestApplication.Domain.Common.Interfaces;
using EntityFrameworkCore.CosmosDb.TestApplication.Domain.Repositories;
using EntityFrameworkCore.CosmosDb.TestApplication.Domain.Repositories.Associations;
using EntityFrameworkCore.CosmosDb.TestApplication.Domain.Repositories.Inheritance;
using EntityFrameworkCore.CosmosDb.TestApplication.Domain.Repositories.InheritanceAssociations;
using EntityFrameworkCore.CosmosDb.TestApplication.Domain.Repositories.NestedComposition;
using EntityFrameworkCore.CosmosDb.TestApplication.Domain.Repositories.Polymorphic;
using EntityFrameworkCore.CosmosDb.TestApplication.Infrastructure.Persistence;
using EntityFrameworkCore.CosmosDb.TestApplication.Infrastructure.Repositories;
using EntityFrameworkCore.CosmosDb.TestApplication.Infrastructure.Repositories.Associations;
using EntityFrameworkCore.CosmosDb.TestApplication.Infrastructure.Repositories.Inheritance;
using EntityFrameworkCore.CosmosDb.TestApplication.Infrastructure.Repositories.InheritanceAssociations;
using EntityFrameworkCore.CosmosDb.TestApplication.Infrastructure.Repositories.NestedComposition;
using EntityFrameworkCore.CosmosDb.TestApplication.Infrastructure.Repositories.Polymorphic;
using EntityFrameworkCore.CosmosDb.TestApplication.Infrastructure.Services;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Infrastructure.DependencyInjection.DependencyInjection", Version = "1.0")]

namespace EntityFrameworkCore.CosmosDb.TestApplication.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>((sp, options) =>
            {
                options.UseCosmos(
                    configuration["Cosmos:AccountEndpoint"],
                    configuration["Cosmos:AccountKey"],
                    configuration["Cosmos:DatabaseName"]);
                options.UseLazyLoadingProxies();
            });
            services.AddScoped<IUnitOfWork>(provider => provider.GetService<ApplicationDbContext>());
            services.AddTransient<IA_RequiredCompositeRepository, A_RequiredCompositeRepository>();
            services.AddTransient<IAbstractBaseClassAssociatedRepository, AbstractBaseClassAssociatedRepository>();
            services.AddTransient<IAssociatedRepository, AssociatedRepository>();
            services.AddTransient<IB_OptionalAggregateRepository, B_OptionalAggregateRepository>();
            services.AddTransient<IB_OptionalDependentRepository, B_OptionalDependentRepository>();
            services.AddTransient<IBaseRepository, BaseRepository>();
            services.AddTransient<IBaseAssociatedRepository, BaseAssociatedRepository>();
            services.AddTransient<IC_RequiredCompositeRepository, C_RequiredCompositeRepository>();
            services.AddTransient<IClassARepository, ClassARepository>();
            services.AddTransient<IConcreteBaseClassRepository, ConcreteBaseClassRepository>();
            services.AddTransient<IConcreteBaseClassAssociatedRepository, ConcreteBaseClassAssociatedRepository>();
            services.AddTransient<ID_MultipleDependentRepository, D_MultipleDependentRepository>();
            services.AddTransient<ID_OptionalAggregateRepository, D_OptionalAggregateRepository>();
            services.AddTransient<IDerivedRepository, DerivedRepository>();
            services.AddTransient<IDerivedClassForAbstractRepository, DerivedClassForAbstractRepository>();
            services.AddTransient<IDerivedClassForAbstractAssociatedRepository, DerivedClassForAbstractAssociatedRepository>();
            services.AddTransient<IDerivedClassForConcreteRepository, DerivedClassForConcreteRepository>();
            services.AddTransient<IDerivedClassForConcreteAssociatedRepository, DerivedClassForConcreteAssociatedRepository>();
            services.AddTransient<IE_RequiredCompositeNavRepository, E_RequiredCompositeNavRepository>();
            services.AddTransient<IExplicitKeyClassRepository, ExplicitKeyClassRepository>();
            services.AddTransient<IF_OptionalAggregateNavRepository, F_OptionalAggregateNavRepository>();
            services.AddTransient<IF_OptionalDependentRepository, F_OptionalDependentRepository>();
            services.AddTransient<IG_RequiredCompositeNavRepository, G_RequiredCompositeNavRepository>();
            services.AddTransient<IH_MultipleDependentRepository, H_MultipleDependentRepository>();
            services.AddTransient<IH_OptionalAggregateNavRepository, H_OptionalAggregateNavRepository>();
            services.AddTransient<IImplicitKeyClassRepository, ImplicitKeyClassRepository>();
            services.AddTransient<IJ_MultipleAggregateRepository, J_MultipleAggregateRepository>();
            services.AddTransient<IJ_RequiredDependentRepository, J_RequiredDependentRepository>();
            services.AddTransient<IK_SelfReferenceRepository, K_SelfReferenceRepository>();
            services.AddTransient<IM_SelfReferenceBiNavRepository, M_SelfReferenceBiNavRepository>();
            services.AddTransient<IPoly_ConcreteARepository, Poly_ConcreteARepository>();
            services.AddTransient<IPoly_ConcreteBRepository, Poly_ConcreteBRepository>();
            services.AddTransient<IPoly_SecondLevelRepository, Poly_SecondLevelRepository>();
            services.AddTransient<IWeirdClassRepository, WeirdClassRepository>();
            services.AddScoped<IDomainEventService, DomainEventService>();
            return services;
        }
    }
}