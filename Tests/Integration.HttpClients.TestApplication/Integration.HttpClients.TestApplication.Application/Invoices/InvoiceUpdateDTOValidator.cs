using System;
using FluentValidation;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.FluentValidation.Dtos.DTOValidator", Version = "1.0")]

namespace Integration.HttpClients.TestApplication.Application.Invoices
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class InvoiceUpdateDTOValidator : AbstractValidator<InvoiceUpdateDTO>
    {
        [IntentManaged(Mode.Fully, Body = Mode.Ignore, Signature = Mode.Merge)]
        public InvoiceUpdateDTOValidator()
        {
            ConfigureValidationRules();
        }

        [IntentManaged(Mode.Fully)]
        private void ConfigureValidationRules()
        {
            RuleFor(v => v.Reference)
                .NotNull();

        }
    }
}