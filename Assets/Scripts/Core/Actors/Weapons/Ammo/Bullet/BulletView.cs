using Asteroids.Core.Actors.Common;
using Asteroids.Core.Actors.Weapons.Arms.Gun;

namespace Asteroids.Core.Actors.Weapons.Ammo.Bullet {
    public class BulletView : EntityView<BulletState, BulletConfig> {

        protected override void SubscribeEvents() {
            State.active.Enabled += FireHandle;
        }

        private void FireHandle() { }

    }
}