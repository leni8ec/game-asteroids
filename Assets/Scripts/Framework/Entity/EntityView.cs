using UnityEngine;

namespace Asteroids.Framework.Entity {
    public abstract class EntityView<TState, TConfig> : MonoBehaviour, IEntityView
        where TState : EntityState
        where TConfig : EntityConfig {

        public GameObject GameObject { get; private set; }
        public Transform Transform { get; private set; }

        protected TState State { get; private set; }
        protected TConfig Config { get; private set; }


        protected virtual void Awake() {
            Transform = transform;
            GameObject = gameObject;
        }

        /// <summary>
        /// Called when entity is created.
        /// <para> - After entity data (state and config) - is set.</para>
        /// <para> - After 'Awake' and before 'Start'</para>
        /// </summary>
        public void Initialize(EntityConfig config, EntityState state) {
            Config = (TConfig) config;
            State = (TState) state;

            // Subscribe to entity active state changes
            State.Active.Changed += active => GameObject.SetActive(active);

            SubscribeEvents();
            OnCreate();
        }


        /// <summary>
        /// Subscribe for entity events and data changes (called after 'Awake' and before 'OnCreate', 'Start')
        /// </summary>
        protected abstract void SubscribeEvents();

        /// <summary>
        /// Called when Entity is created (called after 'Awake', 'SubscribeEvents' and before 'Start')
        /// </summary>
        protected virtual void OnCreate() { }

    }
}