using Asteroids.Framework.Entity.Services.Spawner;
using JetBrains.Annotations;

namespace Asteroids.Core.Actors.Player.Services {
    [UsedImplicitly]
    public class PlayerSpawner : GenericEntitySpawner<Player, PlayerFactory, PlayerConfig> {
        public PlayerSpawner(PlayerFactory factory) : base(factory) { }
    }
}