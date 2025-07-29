using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Asteroids.Framework.Entity {

    public abstract class Entity<TState, TConfig> : EntityBase
        where TState : EntityState
        where TConfig : EntityConfig {

        public TConfig Config { get; private set; }
        public TState State { get; private set; }

        // Sugar
        protected Transform Transform => State.Transform;
        public override Vector3 Position { get => Transform.position; set => Transform.position = value; }
        public override Vector3 Rotation { get => Transform.eulerAngles; set => Transform.eulerAngles = value; }
        public override Vector3 Forward => Transform.up;

        public override event Action DespawnEvent;

        public sealed override void Initialize(EntityConfig config, EntityState state) {
            Config = (TConfig) config;
            State = (TState) state;
            Create();
        }

        protected sealed override void Create() {
            OnCreate();
        }

        public override void SetActive(bool active) {
            State.Active.Set(active);
        }

        public sealed override void Reset() {
            OnReset();
            SetActive(false);
            State.Reset();
            DespawnEvent = null;
        }

        public sealed override void Kill() {
            OnKill();
            Despawn();
        }

        public sealed override void Despawn() {
            DespawnEvent?.Invoke();
        }

        public sealed override void Destroy() {
            OnDestroy();
            Object.Destroy(Transform.gameObject);
        }


        /// <summary>
        /// Called when entity is created.
        /// <para>After data (state and config) - are set.</para>
        /// </summary>
        protected virtual void OnCreate() { }

        /// <summary>
        /// Called on kill entity
        /// </summary>
        protected virtual void OnKill() { }

        /// <summary>
        /// Called after 'Despawn' before 'Destroy'
        /// </summary>
        protected virtual void OnReset() { }

        /// <summary>
        /// Called on destroy entity (before reset)
        /// </summary>
        protected virtual void OnDestroy() { }

    }
}