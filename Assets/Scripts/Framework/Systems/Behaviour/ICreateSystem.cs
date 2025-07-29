namespace Asteroids.Framework.Systems.Behaviour {
    public interface ICreateSystem : ISystem {

        /// <summary>
        /// Called after all systems constructors are processed (when objects are created)
        /// <br/>
        /// <br/> Called before 'Enable()' and `Start()`
        /// </summary>
        void CreateSystem();

    }
}