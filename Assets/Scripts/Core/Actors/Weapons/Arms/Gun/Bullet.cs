using Asteroids.Core.Actors.Weapons.Ammo;
using Asteroids.Core.Actors.Weapons.Ammo.Bullet;

namespace Asteroids.Core.Actors.Weapons.Arms.Gun {
    public class Bullet : Ammo<BulletState, BulletConfig>, IBullet {

        public void Emit() {
            State.lifetime = Config.lifetime;
        }

        public override void Upd(float deltaTime) {
            Transform.Translate(State.Direction * (Config.speed * deltaTime));

            if ((State.lifetime -= deltaTime) <= 0) Kill();
        }
    }
}