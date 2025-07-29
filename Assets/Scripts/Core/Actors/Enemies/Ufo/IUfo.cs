using Asteroids.Framework.Entity;

namespace Asteroids.Core.Actors.Enemies.Ufo {
    public interface IUfo : IEntity {

        /**
         * Stay on target and go to him
         */
        void StartHunt();

    }
}