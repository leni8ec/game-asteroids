namespace Asteroids.Framework.Systems.Behaviour {
    public interface IFixedUpdateSystem : ISystem {

        /// <summary>
        /// Called every fixed update when the system is Active
        /// </summary>
        void FixedUpdateSystem(float fixedDeltaTime);

    }
}