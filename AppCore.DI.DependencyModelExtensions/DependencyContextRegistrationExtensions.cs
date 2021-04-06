// Licensed under the MIT License.
// Copyright (c) 2018-2021 the AppCore .NET project.

using System;
using AppCore.Diagnostics;
using Microsoft.Extensions.DependencyModel;

namespace AppCore.DependencyInjection
{
    /// <summary>
    /// Provides extension methods for registering components with the <see cref="IComponentRegistry"/> via assembly scanning.
    /// </summary>
    public static class DependencyContextRegistrationExtensions
    {
        /// <summary>
        /// Adds components by scanning all assemblies included in a <see cref="DependencyContext"/>.
        /// </summary>
        /// <param name="registry">The <see cref="IComponentRegistry"/>.</param>
        /// <param name="configureBuilder">The builder.</param>
        /// <returns>The <see cref="IComponentRegistry"/>.</returns>
        /// <exception cref="ArgumentNullException">Argument <paramref name="registry"/> or <paramref name="configureBuilder"/> is <c>null</c>. </exception>
        public static IComponentRegistry AddFromDependencyContext(
            this IComponentRegistry registry,
            Action<DependencyContextRegistrationBuilder> configureBuilder)
        {
            Ensure.Arg.NotNull(registry, nameof(registry));
            Ensure.Arg.NotNull(configureBuilder, nameof(configureBuilder));

            var builder = new DependencyContextRegistrationBuilder();
            configureBuilder(builder);

            return registry.Add(builder.BuildRegistrations());
        }
    }
}
