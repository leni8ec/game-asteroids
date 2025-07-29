using System;

namespace Asteroids.Framework.DI.Container {
    public interface IDependencyContainer {


    #region Rgister

        /// <param name="lifeCycle">Singleton by default</param>
        void Register<TInstance>(LifeCycle lifeCycle = LifeCycle.Singleton);

        /// <inheritdoc cref="Register{TInstance}(Asteroids.Framework.DI.Container.LifeCycle)"/>
        void Register(Type instanceType, LifeCycle lifeCycle = LifeCycle.Singleton);

        /// <inheritdoc cref="Register{TInstance}(Asteroids.Framework.DI.Container.LifeCycle)"/>
        void Register<TAbstract, TInstance>(LifeCycle lifeCycle = LifeCycle.Singleton);

        /// <inheritdoc cref="Register{TInstance}(Asteroids.Framework.DI.Container.LifeCycle)"/>
        void Register(Type abstractType, Type instanceType, LifeCycle lifeCycle = LifeCycle.Singleton);

    #endregion


    #region Register predefined singleton instances

        void RegisterInstance(object instance);

        void RegisterInstance<TAbstract>(object instance);

        void RegisterInstance(Type abstractType, object instance);

    #endregion


    #region Resolvers

        TAbstract Resolve<TAbstract>();

        object Resolve(Type abstractType);

        TInstance ResolveUnregistered<TInstance>();

        object ResolveUnregistered(Type instanceType);

    #endregion


    }
}