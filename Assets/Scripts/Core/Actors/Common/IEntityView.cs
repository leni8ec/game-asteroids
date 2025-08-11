using UnityEngine;

namespace Asteroids.Core.Actors.Common {
    public interface IEntityView {

        GameObject GameObject { get; }
        Transform Transform { get; }

        public void Initialize(EntityConfig config, IEntityState state);

    }
}