using System.Collections.Generic;
using Intent.Engine;
using Intent.Modelers.Services.Api;
using Intent.Modules.Application.AutoMapper;
using Intent.Modules.Application.Dtos.Templates.DtoModel;
using Intent.Modules.Common;
using Intent.Modules.Common.CSharp.Templates;
using Intent.Modules.Common.Templates;
using Intent.Modules.Constants;
using Intent.RoslynWeaver.Attributes;
using Intent.Templates;

[assembly: DefaultIntentManaged(Mode.Merge)]
[assembly: IntentTemplate("Intent.ModuleBuilder.CSharp.Templates.CSharpTemplatePartial", Version = "1.0")]

namespace Intent.Modules.Application.Dtos.AutoMapper.Templates.MappingExtensions
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    partial class MappingExtensionsTemplate : CSharpTemplateBase<DTOModel>
    {
        [IntentManaged(Mode.Fully)]
        public const string TemplateId = "Intent.Application.Dtos.AutoMapper.MappingExtensions";

        [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
        public MappingExtensionsTemplate(IOutputTarget outputTarget, DTOModel model) : base(TemplateId, outputTarget, model)
        {
            AddNugetDependency(NugetPackages.AutoMapper);
        }

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        protected override CSharpFileConfig DefineFileConfig()
        {
            return new CSharpFileConfig(
                className: $"{Model.Name}MappingExtensions",
                @namespace: $"{this.GetNamespace()}",
                relativeLocation: this.GetFolderPath());
        }

        private string GetDtoModelName()
        {
            return GetTypeName(DtoModelTemplate.TemplateId, Model);
        }

        private string GetEntityName()
        {
            return TryGetTypeName(TemplateFulfillingRoles.Domain.Entity.Interface, Model.Mapping.ElementId, out var name) 
                   ? name 
                   : GetTypeName(TemplateFulfillingRoles.Domain.ValueObject, Model.Mapping.ElementId);
        }
    }
}