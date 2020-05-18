// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using AppCore.DependencyInjection;
using AppCore.DependencyInjection.Facilities;
using Microsoft.Extensions.Hosting;

namespace AppCore.Hosting.Microsoft.Extensions
{
    public class MicrosoftHostingExtension : FacilityExtension<IHostingFacility>
    {
        protected override void RegisterComponents(IComponentRegistry registry, IHostingFacility facility)
        {
            registry.Register<IHostedService>()
                    .Add<MicrosoftHostingAdapter>()
                    .IfNotRegistered();
        }
    }
}