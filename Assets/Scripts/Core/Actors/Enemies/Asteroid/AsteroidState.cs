using Asteroids.Core.Actors.Common;

namespace Asteroids.Core.Actors.Enemies.Asteroid {

    public interface IAsteroidState : IEntityViewState { }


    public class AsteroidState : EntityState, IAsteroidState {

        protected override void OnReset() { }

    }

}