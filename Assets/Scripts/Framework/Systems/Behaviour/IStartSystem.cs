namespace Asteroids.Framework.Systems.Behaviour {
    public interface IStartSystem : ISystem {

        /// <summary>
        /// Called only once when the system is first enabled
        /// </summary>
        /// <remarks> Called after 'OnEnableSystem()' </remarks>
        void Start();

    }
}