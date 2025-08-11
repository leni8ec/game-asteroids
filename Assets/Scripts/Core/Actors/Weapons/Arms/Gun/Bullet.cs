using Asteroids.Core.Actors.Weapons.Ammo;
using Asteroids.Core.Actors.Weapons.Ammo.Bullet;

namespace Asteroids.Core.Actors.Weapons.Arms.Gun {
    public class Bullet : Ammo<BulletState, BulletConfig>, IBullet {

        public void Emit() {
            State.Lifetime = Config.Lifetime;
        }

        public override void Upd(float deltaTime) {
            Transform.Translate(State.direction * (Config.Speed * deltaTime));

            if ((State.Lifetime -= deltaTime) <= 0) Kill();
        }
    }
}