﻿using System;
using System.Collections.Generic;
using System.Text;
using Intent.Modules.Common.VisualStudio;

namespace Intent.Modules.Application.MediatR.Templates
{
    public class NuGetPackages
    {
        public static INugetPackageInfo MediatR = new NugetPackageInfo("MediatR", "10.0.1");
        public static INugetPackageInfo MicrosoftExtensionsLogging = new NugetPackageInfo("Microsoft.Extensions.Logging", "6.0.0");
    }
}
