using Asteroids.Core.Actors.Common;
using Asteroids.Core.Actors.Player;
using Asteroids.Framework.State;

namespace Asteroids.Core.World.Collision {
    public class CollisionState : IState {

        public event EnemyHitEvent EnemyHitEvent;
        public event PlayerHitEvent PlayerHitEvent;

        public void Reset() {
            // PlayerHitEvent = default;
            // EnemyHitEvent = default;
        }


        public void RegisterEnemyHitPublisher(out EnemyHitEvent publisher) {
            publisher = (enemy, source) => EnemyHitEvent?.Invoke(enemy, source);
        }

        public void RegisterPlayerHitPublisher(out PlayerHitEvent publisher) {
            publisher = (player, source) => PlayerHitEvent?.Invoke(player, source);
        }

    }

    public delegate void PlayerHitEvent(IPlayer player, IEntity source);
    public delegate void EnemyHitEvent(ICollider enemy, ICollider source);
}