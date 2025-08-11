using Asteroids.Core.Actors.Common;

namespace Asteroids.Core.Actors.Enemies.Ufo {
    public interface IUfo : IEntity {

        /**
         * Stay on target and go to him
         */
        void StartHunt();

    }
}