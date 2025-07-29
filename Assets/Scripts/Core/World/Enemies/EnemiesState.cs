using Asteroids.Framework.State;

namespace Asteroids.Core.World.Enemies {
    public class EnemiesState : IState {

        public float asteroidSpawnCountdown;
        public float ufoSpawnCountdown;


        public void Reset() {
            asteroidSpawnCountdown = default;
            ufoSpawnCountdown = default;
        }

    }
}