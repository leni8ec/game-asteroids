using Asteroids.Framework.DI.Content.Bunch;
using Asteroids.Framework.Entity.Services.Factory;
using JetBrains.Annotations;

namespace Asteroids.Core.Actors.Enemies.Asteroid.Services {
    [UsedImplicitly]
    public class AsteroidFactory : EntityBunchFactory<Asteroid, AsteroidView, AsteroidState, AsteroidConfig, AsteroidSize> {
        public AsteroidFactory(Insert<AsteroidSize, AsteroidConfig> configs) : base(configs) { }
    }
}