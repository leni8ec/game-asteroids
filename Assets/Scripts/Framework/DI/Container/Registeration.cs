using System;

namespace Asteroids.Framework.DI.Container {
    internal class Registration {

        public Type AbstractType { get; }
        private Type InstanceType { get; }
        private LifeCycle LifeCycle { get; }

        private object Instance { get; set; }
        private InstanceProvider Provider { get; }

        public Registration(Type abstractType, Type instanceType, LifeCycle lifeCycle, InstanceProvider provider)
            : this(abstractType, instanceType, lifeCycle) {
            Provider = provider;
        }

        public Registration(Type abstractType, LifeCycle lifeCycle, object instance)
            : this(abstractType, instance.GetType(), lifeCycle) {
            Instance = instance;
        }

        private Registration(Type abstractType, Type instanceType, LifeCycle lifeCycle) {
            AbstractType = abstractType;
            InstanceType = instanceType;
            LifeCycle = lifeCycle;
        }

        public object TakeInstance() {
            return LifeCycle switch {
                LifeCycle.Singleton => Instance ??= Provider.SpawnInstanceOf(InstanceType),
                LifeCycle.Transient => Provider.SpawnInstanceOf(InstanceType),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public override string ToString() {
            return $"{LifeCycle}: {(Instance == null ? "null" : Instance.GetType().Name)} " +
                   $"{{ {InstanceType.Name} : {AbstractType.Name} }}";
        }
    }
}