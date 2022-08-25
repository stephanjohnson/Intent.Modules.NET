using System.ComponentModel;
using Intent.Engine;
using Intent.Modules.Common.Registrations;
using Intent.Modules.Eventing.MassTransit.Templates.Consumer;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.ModuleBuilder.Templates.TemplateDecoratorRegistration", Version = "1.0")]

namespace Intent.Modules.Eventing.MassTransit.EntityFrameworkCore.Decorators
{
    [Description(ConsumerTransactionDecorator.DecoratorId)]
    public class ConsumerTransactionDecoratorRegistration : DecoratorRegistration<ConsumerTemplate, ConsumerDecorator>
    {
        public override ConsumerDecorator CreateDecoratorInstance(ConsumerTemplate template, IApplication application)
        {
            return new ConsumerTransactionDecorator(template, application);
        }

        public override string DecoratorId => ConsumerTransactionDecorator.DecoratorId;
    }
}