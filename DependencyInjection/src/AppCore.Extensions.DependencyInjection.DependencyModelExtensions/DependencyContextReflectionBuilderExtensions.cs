// Licensed under the MIT License.
// Copyright (c) 2018-2021 the AppCore .NET project.

using System;
using AppCore.DependencyInjection.Facilities;
using AppCore.Diagnostics;
using AppCore.Extensions.DependencyInjection;
using AppCore.Extensions.DependencyInjection.Facilities;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Provides extension methods to resolve service descriptors and facilities by reflection.
/// </summary>
public static class DependencyContextReflectionBuilderExtensions
{
    /// <summary>
    /// Adds service descriptors by reflection.
    /// </summary>
    /// <param name="builder">The <see cref="IServiceDescriptorReflectionBuilder"/>.</param>
    /// <param name="configure">The delegate to configure the <see cref="DependencyContextServiceDescriptorResolver"/>.</param>
    /// <returns>The <see cref="IServiceDescriptorReflectionBuilder"/>.</returns>
    /// <exception cref="ArgumentNullException">Argument <paramref name="builder"/> is <c>null</c>. </exception>
    public static IServiceDescriptorReflectionBuilder DependencyContext(
        this IServiceDescriptorReflectionBuilder builder,
        Action<DependencyContextServiceDescriptorResolver>? configure = null)
    {
        Ensure.Arg.NotNull(builder);
        Ensure.Arg.NotNull(configure);

        return builder.AddResolver(configure);
    }

    /// <summary>
    /// Adds facilities by reflection.
    /// </summary>
    /// <param name="builder">The <see cref="IFacilityReflectionBuilder"/>.</param>
    /// <param name="configure">The delegate to configure the <see cref="DependencyContextResolver"/>.</param>
    /// <returns>The <see cref="IServiceDescriptorReflectionBuilder"/>.</returns>
    /// <exception cref="ArgumentNullException">Argument <paramref name="builder"/> or <paramref name="configure"/> is <c>null</c>. </exception>
    public static IFacilityReflectionBuilder DependencyContext(
        this IFacilityReflectionBuilder builder,
        Action<DependencyContextResolver> configure)
    {
        Ensure.Arg.NotNull(builder);
        Ensure.Arg.NotNull(configure);

        return builder.AddResolver(configure);
    }

    /// <summary>
    /// Adds facility extensions by reflection.
    /// </summary>
    /// <param name="builder">The <see cref="IFacilityExtensionReflectionBuilder"/>.</param>
    /// <param name="configure">The delegate to configure the <see cref="DependencyContextResolver"/>.</param>
    /// <returns>The <see cref="IFacilityExtensionReflectionBuilder"/>.</returns>
    /// <exception cref="ArgumentNullException">Argument <paramref name="builder"/> or <paramref name="configure"/> is <c>null</c>. </exception>
    public static IFacilityExtensionReflectionBuilder DependencyContext(
        this IFacilityExtensionReflectionBuilder builder,
        Action<DependencyContextResolver> configure)
    {
        Ensure.Arg.NotNull(builder);
        Ensure.Arg.NotNull(configure);

        return builder.AddResolver(configure);
    }
}