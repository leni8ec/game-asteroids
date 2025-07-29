using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Asteroids.Framework.DI.Container {
    /// Default instance provider
    internal class InstanceProvider {

        public delegate object ContainerResolveMethod(Type type);
        private readonly ContainerResolveMethod resolveMethod;

        public InstanceProvider(ContainerResolveMethod resolveMethod) {
            this.resolveMethod = resolveMethod;
        }

        public object SpawnInstanceOf(Type type) {
            IEnumerable<object> parameters = ResolveConstructorParameters(type);
            return CreateInstance(type, parameters.ToArray());
        }

        private IEnumerable<object> ResolveConstructorParameters(Type type) {
            ConstructorInfo[] constructors = type.GetConstructors();
            if (constructors.Length == 0)
                throw new DependencyResolveException($"No public constructors found for: {type.Name} ({type})");

            ConstructorInfo constructorInfo = constructors.First();
            foreach (ParameterInfo parameter in constructorInfo.GetParameters()) {
                yield return resolveMethod(parameter.ParameterType);
            }
        }

        private object CreateInstance(Type type, params object[] args) {
            return Activator.CreateInstance(type, args);
        }

    }
}