using System;
using Asteroids.Framework.Behavior;

namespace Asteroids.Core.Actors.Common {

    public interface IEntity : IDestroy, IReset, IUpdate {

        event Action DespawnEvent;

        public void Initialize(EntityConfig config, EntityState state);

        void SetActive(bool active);

        void Kill();

        void Spawned();

        void Despawn();


        // Live states (ICreate, ISpawnable (spawn, despawn)
        // - Exists: Create / Destroy (object)
        // - Spawned: Spawn / Despawn (spawned objects)
        // - Active: Activate / Deactivate (active state)
        // event Action SpawnEvent;
        // event Action DespawnEvent;
        // void Spawn();
        // void Despawn();
    }

}