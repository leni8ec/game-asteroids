using Asteroids.Core.World.Collision;
using Asteroids.Core.World.Enemies;
using Asteroids.Core.World.Entities.State;
using Asteroids.Core.World.Game;
using Asteroids.Core.World.Score;
using Asteroids.Core.World.Weapon;
using Asteroids.Framework.DI.Container;
using Asteroids.Framework.DI.Context;

namespace Asteroids.Core.World.Common.Context {
    public class WorldStateContext : IDependencyContext {

        public void InstallTo(IDependencyContainer container) {
            container.RegisterInstance(new CollisionState());
            container.RegisterInstance(new EntitiesState());
            container.RegisterInstance(new EnemiesState());
            container.RegisterInstance(new WeaponState());
            container.RegisterInstance(new GameState());
            container.RegisterInstance(new ScoreState());
        }
    }
}