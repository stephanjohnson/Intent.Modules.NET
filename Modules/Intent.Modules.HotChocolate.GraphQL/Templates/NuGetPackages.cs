using Intent.Modules.Common.VisualStudio;

namespace Intent.Modules.HotChocolate.GraphQL.Templates
{
    public static class NuGetPackages
    {
        public static INugetPackageInfo HotChocolate => new NugetPackageInfo("HotChocolate", "12.7.0");
    }
}