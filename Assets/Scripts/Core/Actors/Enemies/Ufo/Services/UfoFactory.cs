using Asteroids.Core.Actors.Common.Services.Factory;
using JetBrains.Annotations;

namespace Asteroids.Core.Actors.Enemies.Ufo.Services {
    [UsedImplicitly]
    public class UfoFactory : EntityFactory<Ufo, UfoView, UfoState, UfoConfig> {
        public UfoFactory(UfoConfig config) : base(config) { }
    }
}