// Licensed under the MIT License.
// Copyright (c) 2018-2021 the AppCore .NET project.

using AppCore.DependencyInjection.Facilities;
using Microsoft.Extensions.DependencyInjection;

namespace AppCore.DependencyInjection
{
    public class Facility1 : Facility
    {
        protected override void ConfigureServices(IServiceCollection services)
        {
        }
    }
}