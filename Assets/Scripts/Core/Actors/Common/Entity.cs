using System;
using Asteroids.Framework.Reactive;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Asteroids.Core.Actors.Common {

    public abstract class Entity<TState, TConfig> : EntityBase
        where TState : EntityState
        where TConfig : EntityConfig {

        /// <remarks> Entity config is protected from public use </remarks>
        protected TConfig Config { get; private set; }
        public TState State { get; private set; }

        public IReactiveFlag Active => State.active;

        public override Transform Transform => State.Transform;
        public override Vector3 Position { get => Transform.position; set => Transform.position = value; }
        public override float Rotation {
            get => Transform.eulerAngles.z;
            set {
                Vector3 angles = Transform.eulerAngles;
                angles.z = value;
                Transform.eulerAngles = angles;
            }
        }

        public override Vector3 Direction => State.direction;
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
            State.active.Set(active);
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

        public sealed override void Spawned() {
            OnSpawned();
        }

        public sealed override void Despawn() {
            OnDespawn();
            DespawnEvent?.Invoke();
        }

        public sealed override void Destroy() {
            OnDestroy();
            Object.Destroy(Transform.gameObject);
        }


        /// <summary>
        /// Called when entity is first created.
        /// <para>After data (state and config) - are set.</para>
        /// </summary>
        protected virtual void OnCreate() { }

        /// <summary>
        /// Called each time on entity spawned
        /// </summary>
        protected virtual void OnSpawned() { }

        /// <summary>
        /// Called each time on despawn entity
        /// </summary>
        protected virtual void OnDespawn() { }

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