using Asteroids.Core.Actors.Weapons.Ammo;
using Asteroids.Core.Actors.Weapons.Ammo.LaserRay;

namespace Asteroids.Core.Actors.Weapons.Arms.Laser {
    public class Laser : Ammo<LaserRayState, LaserConfig>, ILaser {

        public float MaxDistance => Config.maxDistance;

        public void Emit() {
            State.duration = Config.duration;
            Transform.up = State.Direction;
        }

        public override void Upd(float deltaTime) {
            if ((State.duration -= deltaTime) < 0) {
                Kill();
            }
        }

    }
}