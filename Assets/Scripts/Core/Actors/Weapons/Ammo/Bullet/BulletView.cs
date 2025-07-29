using Asteroids.Core.Actors.Weapons.Arms.Gun;
using Asteroids.Framework.Entity;

namespace Asteroids.Core.Actors.Weapons.Ammo.Bullet {
    public class BulletView : EntityView<BulletState, BulletConfig> {

        protected override void SubscribeEvents() {
            State.Active.Enabled += FireHandle;
        }

        private void FireHandle() { }

    }
}