using Asteroids.Core.World.Audio;
using Asteroids.Core.World.Collision;
using Asteroids.Core.World.Common.Systems;
using Asteroids.Core.World.Enemies;
using Asteroids.Core.World.Enemies.Asteroids;
using Asteroids.Core.World.Entities.Systems;
using Asteroids.Core.World.Game;
using Asteroids.Core.World.Players;
using Asteroids.Core.World.Score;
using Asteroids.Core.World.Screen;
using Asteroids.Core.World.Weapon;
using Asteroids.Framework.DI.Container;
using Asteroids.Framework.DI.Context;

namespace Asteroids.Core.World.Common.Context {
    internal class WorldSystemsContext : IDependencyContext {

        public void InstallTo(IDependencyContainer container) {
            container.Register<IInfinityScreenSystem, InfinityScreenSystem>();
            container.Register<IGameStateSystem, GameStateSystem>();

            container.Register<IEntityActiveRegisterSystem, EntityActiveRegisterSystem>();
            container.Register<IEntityUpdateSystem, EntityUpdateSystem>();
            container.Register<IEntityKillSystem, EntityKillSystem>();

            container.Register<IPlayersSystem, PlayersSystem>();
            container.Register<IEnemiesSystem, EnemiesSystem>();
            container.Register<IAsteroidKillSystem, AsteroidKillSystem>();

            container.Register<IWeaponSystem, WeaponSystem>();
            container.Register<ICollisionSystem, CollisionSystem>();
            container.Register<IWorldClearSystem, WorldClearSystem>();

            container.Register<IAudioSystem, AudioSystem>();
            container.Register<IScoreSystem, ScoreSystem>();
        }
    }
}