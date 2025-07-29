using Asteroids.Framework.State;

namespace Asteroids.Core.World.Enemies {
    public class EnemiesState : IState {

        public float AsteroidSpawnCountdown { get; internal set; }
        public float UfoSpawnCountdown { get; internal set; }


        public void Reset() {
            AsteroidSpawnCountdown = default;
            UfoSpawnCountdown = default;
        }

    }
}