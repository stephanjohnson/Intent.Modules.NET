using System.Threading.Tasks;
using CleanArchitecture.TestApplication.Domain.Common;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.DomainEvents.DomainEventServiceInterface", Version = "1.0")]

namespace CleanArchitecture.TestApplication.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}