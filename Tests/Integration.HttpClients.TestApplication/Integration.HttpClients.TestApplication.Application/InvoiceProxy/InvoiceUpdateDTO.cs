using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Contracts.Clients.DtoContract", Version = "1.0")]

namespace Integration.HttpClients.TestApplication.Application.InvoiceProxy
{
    public class InvoiceUpdateDTO
    {
        public static InvoiceUpdateDTO Create(
            string reference)
        {
            return new InvoiceUpdateDTO
            {
                Reference = reference,
            };
        }
        public string Reference { get; set; }
    }
}