﻿using System.Collections.Generic;
using Core.Interface.Containers;
using Core.Interface.Objects;
using Core.Interface.State;
using Core.Interface.View;
using Core.Objects.Base;
using Core.State.Base;
using UnityEngine;

namespace Core.Pools.Base {
    /// <summary>
    /// Call 'Entity.Destroy()' for Return entity to Pool
    /// </summary>
    public class EntityPool<TEntity, TState, TConfig> where TEntity : Entity<TState, TConfig>
        where TState : EntityState, new()
        where TConfig : ScriptableObject, new() {

        private readonly GameObject prefab;
        private readonly TState state;
        private readonly TConfig config;

        private readonly Stack<TEntity> stack = new();
        public readonly List<TEntity> active = new();

        public EntityPool(GameObject prefab, TConfig config) {
            this.prefab = prefab;
            this.config = config;
        }

        private TEntity CreateNewEntity() {
            GameObject entityObject = Object.Instantiate(prefab);
            TEntity entity = (TEntity)entityObject.GetComponent<IEntityView>().Entity;
            entity.SetConfig(config);
            entity.Dispose += e => Return(entity);
            return entity;
        }


        public TEntity Take() {
            if (!stack.TryPop(out TEntity entity)) {
                entity = CreateNewEntity();
            }

            if (!entity.GameObject.activeSelf)
                entity.GameObject.SetActive(true);

            active.Add(entity);
            return entity;
        }

        private void Return(TEntity entity) {
            entity.GameObject.SetActive(false);
            active.Remove(entity);
            stack.Push(entity);
        }

    }
}