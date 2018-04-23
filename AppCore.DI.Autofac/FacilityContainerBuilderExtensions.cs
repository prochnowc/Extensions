﻿// Copyright 2018 the AppCore project.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated
// documentation files (the "Software"), to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and
// to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or substantial portions
// of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING
// BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
// DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System;
using AppCore.DependencyInjection;
using AppCore.Diagnostics;

// ReSharper disable once CheckNamespace
namespace Autofac
{
    public static class FacilityContainerBuilderExtensions
    {
        public static void RegisterFacility(
            this ContainerBuilder builder,
            IFacility facility,
            Action<FacilityBuilder> configure = null)
        {
            Ensure.Arg.NotNull(builder, nameof(builder));

            var registry = new AutofacServiceRegistrar(builder);
            registry.AddFacility(facility, configure);
        }

        public static void RegisterFacility<TFacility>(
            this ContainerBuilder builder,
            Action<FacilityBuilder<TFacility>> configure = null)
            where TFacility : IFacility, new()
        {
            Ensure.Arg.NotNull(builder, nameof(builder));

            var registrar = new AutofacServiceRegistrar(builder);
            registrar.AddFacility(configure);
        }
    }
}