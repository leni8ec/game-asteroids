using System;
using UnityEngine;

namespace Asteroids.Framework.Entity {
    public abstract class EntityBase : IEntity {

        /// <summary>
        /// The world space position
        /// </summary>
        public abstract Vector3 Position { get; set; }
        /// <summary>
        /// The world space rotation as Euler angles in degrees
        /// </summary>
        public abstract Vector3 Rotation { get; set; }
        /// <summary>
        /// The world space forward direction of entity (transform.up)
        /// </summary>
        public abstract Vector3 Forward { get; }


        public abstract event Action DespawnEvent;


        protected abstract void Create();

        public abstract void Initialize(EntityConfig config, EntityState state);

        public abstract void SetActive(bool active);

        public abstract void Upd(float deltaTime);

        /// <summary>
        /// Called when entity is returned to poolable entity spawner
        /// </summary>
        public abstract void Reset();

        /// Kill entity
        /// <br/>
        /// <br/> Gameplay action that should trigger 'Despawn' process
        public abstract void Kill();

        /// Despawn entity
        /// <br/>
        /// <br/> Return to pool (if used) or destroy immediately (otherwise)
        public abstract void Despawn();

        /// Destroy entity
        /// <br/>
        /// <br/> Destroy immediately (not despawn, not return to pool)
        public abstract void Destroy();

    }
}