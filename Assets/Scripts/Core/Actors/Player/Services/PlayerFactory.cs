using Asteroids.Core.Actors.Common.Services.Factory;
using JetBrains.Annotations;

namespace Asteroids.Core.Actors.Player.Services {
    [UsedImplicitly]
    public class PlayerFactory : EntityFactory<Player, PlayerView, PlayerState, PlayerConfig> {
        public PlayerFactory(PlayerConfig config) : base(config) { }
    }
}