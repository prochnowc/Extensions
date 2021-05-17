// Licensed under the MIT License.
// Copyright (c) 2018-2021 the AppCore .NET project.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using AppCore.DependencyInjection.Activator;
using AppCore.Diagnostics;

namespace AppCore.DependencyInjection.Facilities
{
    /// <summary>
    /// Represents a facility.
    /// </summary>
    public abstract class Facility
    {
        private static IActivator _activator = DefaultActivator.Instance;
        private readonly List<Action<IComponentRegistry>> _registrations = new();
        private readonly List<FacilityExtension> _extensions = new();

        /// <summary>
        /// Gets or sets the activator for facilities.
        /// </summary>
        public static IActivator Activator
        {
            get => _activator;
            set
            {
                Ensure.Arg.NotNull(value, nameof(value));
                _activator = value;
            }
        }

        /// <summary>
        /// Registers a callback which is invoked when the facility is built.
        /// </summary>
        /// <param name="callback">The callback.</param>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public void ConfigureRegistry(Action<IComponentRegistry> callback)
        {
            Ensure.Arg.NotNull(callback, nameof(callback));
            _registrations.Add(callback);
        }

        /// <summary>
        /// Adds an extension to the facility.
        /// </summary>
        /// <param name="extensionType">The type of the facility extension.</param>
        /// <param name="configure">The configuration delegate.</param>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public FacilityExtension AddExtension(Type extensionType, Action<FacilityExtension> configure = null)
        {
            Ensure.Arg.NotNull(extensionType, nameof(extensionType));
            Ensure.Arg.OfType(extensionType, typeof(FacilityExtension), nameof(extensionType));

            FacilityExtension extension = _extensions.FirstOrDefault(e => e.GetType() == extensionType);
            if (extension == null)
            {
                extension = (FacilityExtension)Activator.CreateInstance(extensionType);
                _extensions.Add(extension);
            }

            configure?.Invoke(extension);
            return extension;
        }

        /// <summary>
        /// Adds an extension to the facility.
        /// </summary>
        /// <typeparam name="T">The type of the facility extension.</typeparam>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public T AddExtension<T>(Action<T> configure = null)
            where T : FacilityExtension
        {
            return (T) AddExtension(typeof(T), f => configure?.Invoke((T) f));
        }

        /// <summary>
        /// Can be overridden to register components with the <see cref="IComponentRegistry"/>.
        /// </summary>
        /// <param name="registry">The <see cref="IComponentRegistry"/>.</param>
        protected internal virtual void Build(IComponentRegistry registry)
        {
            foreach (Action<IComponentRegistry> registration in _registrations)
            {
                registration(registry);
            }

            foreach (FacilityExtension extension in _extensions)
            {
                extension.Build(registry);
            }
        }
    }
}