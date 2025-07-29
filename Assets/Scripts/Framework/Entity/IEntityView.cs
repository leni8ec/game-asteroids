using UnityEngine;

namespace Asteroids.Framework.Entity {
    public interface IEntityView {

        GameObject GameObject { get; }
        Transform Transform { get; }

        public void Initialize(EntityConfig config, EntityState state);

    }
}