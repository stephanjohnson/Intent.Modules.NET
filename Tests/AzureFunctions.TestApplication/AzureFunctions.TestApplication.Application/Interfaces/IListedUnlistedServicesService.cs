using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Contracts.ServiceContract", Version = "1.0")]

namespace AzureFunctions.TestApplication.Application.Interfaces
{

    public interface IListedUnlistedServicesService : IDisposable
    {

        Task ListedServiceFunc(string param);

        Task UnlistedServiceFunc();

    }
}