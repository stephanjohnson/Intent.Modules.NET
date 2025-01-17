using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.ServiceImplementations.FluentValidation.ValidationServiceInterface", Version = "1.0")]

namespace Standard.AspNetCore.TestApplication.Application.Common.Validation
{
    public interface IValidationService
    {
        Task Handle<TRequest>(TRequest request, CancellationToken cancellationToken = default);
    }
}