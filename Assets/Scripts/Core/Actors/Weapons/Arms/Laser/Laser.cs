using Asteroids.Core.Actors.Weapons.Ammo;
using Asteroids.Core.Actors.Weapons.Ammo.LaserRay;

namespace Asteroids.Core.Actors.Weapons.Arms.Laser {
    public class Laser : Ammo<LaserRayState, LaserConfig>, ILaser {

        public float MaxDistance => Config.MaxDistance;

        public void Emit() {
            State.Duration = Config.Duration;
            Transform.up = State.direction;
        }

        public override void Upd(float deltaTime) {
            if ((State.Duration -= deltaTime) < 0) {
                Kill();
            }
        }

    }
}