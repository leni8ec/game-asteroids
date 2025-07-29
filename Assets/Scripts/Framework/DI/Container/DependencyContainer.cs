using System;
using System.Collections.Generic;
using System.Linq;

namespace Asteroids.Framework.DI.Container {
    public class DependencyContainer : IDependencyContainer {

        private const LifeCycle LIFE_CYCLE_DEFAULT = LifeCycle.Singleton;
        private readonly List<Registration> registry;
        private readonly InstanceProvider instanceProvider;

        public DependencyContainer() {
            registry = new List<Registration>();
            instanceProvider = new InstanceProvider(ResolveInternal);
        }


    #region Register types

        public void Register<TInstance>(LifeCycle lifeCycle = LIFE_CYCLE_DEFAULT) {
            Register(typeof(TInstance), lifeCycle);
        }

        public void Register(Type instanceType, LifeCycle lifeCycle = LifeCycle.Singleton) {
            Register(instanceType, instanceType, lifeCycle);
        }

        public void Register<TAbstract, TInstance>(LifeCycle lifeCycle = LIFE_CYCLE_DEFAULT) {
            Register(typeof(TAbstract), typeof(TInstance), lifeCycle);
        }

        public void Register(Type abstractType, Type instanceType, LifeCycle lifeCycle = LifeCycle.Singleton) {
            registry.Add(new Registration(abstractType, instanceType, lifeCycle, instanceProvider));
        }

    #endregion


    #region Register instances

        public void RegisterInstance(object instance) {
            RegisterInstance(instance.GetType(), instance);
        }

        public void RegisterInstance<TAbstract>(object instance) {
            RegisterInstance(typeof(TAbstract), instance);
        }

        public void RegisterInstance(Type abstractType, object instance) {
            if (instance == null) throw new DependencyRegisterException("Instance cannot be null");
            Registration registration = new(abstractType, LifeCycle.Singleton, instance);
            registry.Add(registration);
        }

    #endregion


    #region Resolvers

        public TAbstract Resolve<TAbstract>() {
            return (TAbstract) ResolveInternal(typeof(TAbstract));
        }

        public object Resolve(Type abstractType) {
            return ResolveInternal(abstractType);
        }

        public TInstance ResolveUnregistered<TInstance>() {
            return (TInstance) ResolveUnregistered(typeof(TInstance));
        }

        public object ResolveUnregistered(Type instanceType) {
            Registration unregisteredObject = new(instanceType, instanceType, LifeCycle.Transient, instanceProvider);
            return unregisteredObject.TakeInstance();
        }

        private object ResolveInternal(Type abstractType) {
            // Registration registration = registry.FirstOrDefault(o => abstractType.IsAssignableFrom(o.AbstractType)); // hack (not used)
            Registration registration = registry.FirstOrDefault(o => o.AbstractType == abstractType);
            if (registration == null)
                throw new DependencyResolveException($"The type {abstractType.Name} has not been registered");

            return registration.TakeInstance();
        }

    #endregion


    }
}