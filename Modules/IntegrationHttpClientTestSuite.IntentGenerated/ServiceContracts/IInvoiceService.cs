using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IntegrationHttpClientTestSuite.IntentGenerated.ServiceContracts.Invoices;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Contracts.ServiceContract", Version = "1.0")]

namespace IntegrationHttpClientTestSuite.IntentGenerated.ServiceContracts
{

    public interface IInvoiceService : IDisposable
    {

        Task Create(InvoiceCreateDTO dto);

        Task<InvoiceDTO> FindById(Guid id);

        Task<List<InvoiceDTO>> FindAll();

        Task Update(Guid id, InvoiceUpdateDTO dto);

        Task Delete(Guid id);

        Task<InvoiceDTO> QueryParamOp(string param1, int param2);

        Task HeaderParamOp(string param1);

        Task FormParamOp(string param1, int param2);

        Task RouteParamOp(string param1);

        Task BodyParamOp(InvoiceDTO param1);

    }
}