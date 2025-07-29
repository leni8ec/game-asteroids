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

        protected T CreateInternal(EntityConfig config) {

            // Create GameObject
            GameObject playerObject = Object.Instantiate(config.Prefab);

            // Create Model
            T model = new();

            // Add State Component
            TState state = playerObject.AddComponent<TState>();

            // Get View Component
            TView view = playerObject.GetComponent<TView>();

            // Initialization
            model.Initialize(config, state);
            view.Initialize(config, state);
            // Setup
            state.Transform = view.Transform;

#if UNITY_EDITOR
            // Editor usability: set State component as first in game object
            int moveSteps = playerObject.GetComponentCount() - 1;
            while (moveSteps-- > 0) ComponentUtility.MoveComponentUp(state);
#endif

            return model;
        }

    }
}