using System.Collections.Generic;
using Intent.Modules.Common.Templates;
using Intent.Modules.Eventing.MassTransit.Templates.Consumer;
using Intent.Modules.Eventing.MassTransit.Templates.EventBusPublisherImplementation;
using Intent.Modules.Eventing.MassTransit.Templates.EventBusPublisherInterface;
using Intent.Modules.Eventing.MassTransit.Templates.IntegrationEventHandlerImplementation;
using Intent.Modules.Eventing.MassTransit.Templates.IntegrationEventHandlerInterface;
using Intent.Modules.Eventing.MassTransit.Templates.IntegrationEventMessage;
using Intent.Modules.Eventing.MassTransit.Templates.MassTransitConfiguration;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: DefaultIntentManaged(Mode.Fully, Targets = Targets.Usings)]
[assembly: IntentTemplate("Intent.ModuleBuilder.Templates.TemplateExtensions", Version = "1.0")]

namespace Intent.Modules.Eventing.MassTransit.Templates
{
    public static class TemplateExtensions
    {
        public static string GetConsumerName<T>(this IntentTemplateBase<T> template) where T : Intent.Modelers.Eventing.Api.MessageHandlerModel
        {
            return template.GetTypeName(ConsumerTemplate.TemplateId, template.Model);
        }

        public static string GetConsumerName(this IntentTemplateBase template, Intent.Modelers.Eventing.Api.MessageHandlerModel model)
        {
            return template.GetTypeName(ConsumerTemplate.TemplateId, model);
        }

        public static string GetEventBusPublisherImplementationName<T>(this IntentTemplateBase<T> template)
        {
            return template.GetTypeName(EventBusPublisherImplementationTemplate.TemplateId);
        }

        public static string GetEventBusPublisherInterfaceName<T>(this IntentTemplateBase<T> template)
        {
            return template.GetTypeName(EventBusPublisherInterfaceTemplate.TemplateId);
        }

        public static string GetIntegrationEventHandlerImplementationName<T>(this IntentTemplateBase<T> template) where T : Intent.Modelers.Eventing.Api.MessageHandlerModel
        {
            return template.GetTypeName(IntegrationEventHandlerImplementationTemplate.TemplateId, template.Model);
        }

        public static string GetIntegrationEventHandlerImplementationName(this IntentTemplateBase template, Intent.Modelers.Eventing.Api.MessageHandlerModel model)
        {
            return template.GetTypeName(IntegrationEventHandlerImplementationTemplate.TemplateId, model);
        }

        public static string GetIntegrationEventHandlerInterfaceName<T>(this IntentTemplateBase<T> template) where T : Intent.Modelers.Eventing.Api.MessageHandlerModel
        {
            return template.GetTypeName(IntegrationEventHandlerInterfaceTemplate.TemplateId, template.Model);
        }

        public static string GetIntegrationEventHandlerInterfaceName(this IntentTemplateBase template, Intent.Modelers.Eventing.Api.MessageHandlerModel model)
        {
            return template.GetTypeName(IntegrationEventHandlerInterfaceTemplate.TemplateId, model);
        }

        public static string GetIntegrationEventMessageName<T>(this IntentTemplateBase<T> template) where T : Intent.Modelers.Eventing.Api.MessageModel
        {
            return template.GetTypeName(IntegrationEventMessageTemplate.TemplateId, template.Model);
        }

        public static string GetIntegrationEventMessageName(this IntentTemplateBase template, Intent.Modelers.Eventing.Api.MessageModel model)
        {
            return template.GetTypeName(IntegrationEventMessageTemplate.TemplateId, model);
        }

        public static string GetMassTransitConfigurationName<T>(this IntentTemplateBase<T> template)
        {
            return template.GetTypeName(MassTransitConfigurationTemplate.TemplateId);
        }

    }
}