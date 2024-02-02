﻿using Core.Interface.Objects;
using UnityEngine;

namespace Core.Objects {
    public abstract class Entity<T> : EntityBase, IEntity where T : ScriptableObject, new() {

        public delegate void DisposeEvent(Entity<T> entity);
        public event DisposeEvent Dispose;

        protected T config;

        public void SetData(T data) {
            this.config = data;
        }

        public abstract float Radius { get; }
        public Vector2 Pos => transform.position;

        public virtual void Reset() {
            Dispose?.Invoke(this);
        }

        public virtual void Destroy() {
            Reset();
        }

    }
}