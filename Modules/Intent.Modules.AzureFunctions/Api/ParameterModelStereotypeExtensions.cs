using System;
using System.Collections.Generic;
using System.Linq;
using Intent.Metadata.Models;
using Intent.Modelers.Services.Api;
using Intent.Modules.Common;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.ModuleBuilder.Templates.Api.ApiElementModelExtensions", Version = "1.0")]

namespace Intent.AzureFunctions.Api
{
    public static class ParameterModelStereotypeExtensions
    {
        public static ParameterSetting GetParameterSetting(this ParameterModel model)
        {
            var stereotype = model.GetStereotype("Parameter Setting");
            return stereotype != null ? new ParameterSetting(stereotype) : null;
        }


        public static bool HasParameterSetting(this ParameterModel model)
        {
            return model.HasStereotype("Parameter Setting");
        }

        public static bool TryGetParameterSetting(this ParameterModel model, out ParameterSetting stereotype)
        {
            if (!HasParameterSetting(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new ParameterSetting(model.GetStereotype("Parameter Setting"));
            return true;
        }


        public class ParameterSetting
        {
            private IStereotype _stereotype;

            public ParameterSetting(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

            public SourceOptions Source()
            {
                return new SourceOptions(_stereotype.GetProperty<string>("Source"));
            }

            public class SourceOptions
            {
                public readonly string Value;

                public SourceOptions(string value)
                {
                    Value = value;
                }

                public SourceOptionsEnum AsEnum()
                {
                    switch (Value)
                    {
                        case "Default":
                            return SourceOptionsEnum.Default;
                        case "From Query":
                            return SourceOptionsEnum.FromQuery;
                        case "From Body":
                            return SourceOptionsEnum.FromBody;
                        case "From Route":
                            return SourceOptionsEnum.FromRoute;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                public bool IsDefault()
                {
                    return Value == "Default";
                }
                public bool IsFromQuery()
                {
                    return Value == "From Query";
                }
                public bool IsFromBody()
                {
                    return Value == "From Body";
                }
                public bool IsFromRoute()
                {
                    return Value == "From Route";
                }
            }

            public enum SourceOptionsEnum
            {
                Default,
                FromQuery,
                FromBody,
                FromRoute
            }
        }

    }
}