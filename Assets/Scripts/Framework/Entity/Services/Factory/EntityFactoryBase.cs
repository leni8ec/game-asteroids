using JetBrains.Annotations;
using UnityEditorInternal;
using UnityEngine;

namespace Asteroids.Framework.Entity.Services.Factory {

    /// Factory method to create new entities
    [UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
    public abstract class EntityFactoryBase<T, TView, TState> : IEntityFactory
        where T : IEntity, new()
        where TView : IEntityView
        where TState : EntityState {

        protected EntityContainer Container { private get; set; }

        protected T CreateInternal(EntityConfig config) {
            // Create GameObject
            GameObject gameObject = Object.Instantiate(config.Prefab);
            Container?.Add(gameObject);

            // Create Model
            T model = new();

            // Add State Component
            TState state = gameObject.AddComponent<TState>();

            // Get View Component
            TView view = gameObject.GetComponent<TView>();

            // Initialization
            model.Initialize(config, state);
            view.Initialize(config, state);
            // Setup
            state.Transform = view.Transform;

#if UNITY_EDITOR
            // Editor usability: set State component as first in game object
            int moveSteps = gameObject.GetComponentCount() - 1;
            while (moveSteps-- > 0) ComponentUtility.MoveComponentUp(state);
#endif

            return model;
        }

        public void UseContainer(string containerName = null) {
            Container = new EntityContainer(containerName);
        }
    }
}