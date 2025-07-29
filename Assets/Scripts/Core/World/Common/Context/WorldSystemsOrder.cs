using System.Collections.Generic;
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
using Asteroids.Framework.DI.Broker;
using Asteroids.Framework.DI.Container;
using Asteroids.Framework.Systems;

namespace Asteroids.Core.World.Common.Context {
    /// <summary>
    /// World systems resolver (with specified order)
    /// </summary>
    /// <remarks>
    /// There is currently no normal solution for prioritizing systems.
    ///  Therefore, this implementation of the system queue (order) can be interpreted as a hack.
    /// </remarks>
    public class WorldSystemsOrder : IDependencyOrder<ISystem> {

        public List<ISystem> ResolveFrom(IDependencyContainer container) {
            return new List<ISystem> {
                container.Resolve<IEntityActiveRegisterSystem>(), //0. Register active entities (from spawners)
                container.Resolve<IPlayersSystem>(), //             1. Players (player control)
                container.Resolve<IWeaponSystem>(), //              2. Weapon (spawn ammo)
                container.Resolve<IEnemiesSystem>(), //             3. Enemies (spawn enemies)
                container.Resolve<IInfinityScreenSystem>(), //      4. Infinity screen
                container.Resolve<IEntityUpdateSystem>(), //        5. Entities update
                container.Resolve<ICollisionSystem>(), //           6. Collision

                container.Resolve<IAsteroidKillSystem>(), //
                container.Resolve<IEntityKillSystem>(), //

                container.Resolve<IAudioSystem>(), //
                container.Resolve<IScoreSystem>(), //

                container.Resolve<IWorldClearSystem>(), //
                container.Resolve<IGameStateSystem>(), //           [Last] NewGame event

            };
        }

    }
}