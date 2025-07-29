namespace Asteroids.Framework.Systems.Behaviour {
    public interface IUpdateSystem : ISystem {

        /// <summary>
        /// Called every frame when system is Active
        /// </summary>
        void UpdateSystem(float deltaTime);

    }
}