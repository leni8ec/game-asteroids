using Asteroids.Core.World.Collision;
using Asteroids.Core.World.Enemies;
using Asteroids.Core.World.Entities.State;
using Asteroids.Core.World.Game;
using Asteroids.Core.World.Players.Common;
using Asteroids.Core.World.Players.Weapons;
using Asteroids.Core.World.Score;
using Asteroids.Framework.DI.Container;
using Asteroids.Framework.DI.Context;

namespace Asteroids.Core.World.Common.Context {
    public class WorldStateContext : IDependencyContext {

        public void InstallTo(IDependencyContainer container) {
            container.RegisterInstance(new CollisionState());
            container.RegisterInstance(new EntitiesState());
            container.RegisterInstance(new EnemiesState());
            container.RegisterInstance(new PlayersState());
            container.RegisterInstance(new WeaponState());
            container.RegisterInstance(new GameState());
            container.RegisterInstance(new ScoreState());
        }
    }
}