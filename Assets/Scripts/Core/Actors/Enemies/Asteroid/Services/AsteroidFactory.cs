using Asteroids.Core.Actors.Common.Services.Factory;
using Asteroids.Framework.DI.Content.Bunch;
using JetBrains.Annotations;

namespace Asteroids.Core.Actors.Enemies.Asteroid.Services {
    [UsedImplicitly]
    public class AsteroidFactory : EntityBunchFactory<Asteroid, AsteroidView, AsteroidState, AsteroidConfig, AsteroidSize> {
        public AsteroidFactory(Insert<AsteroidSize, AsteroidConfig> configs) : base(configs) { }
    }
}