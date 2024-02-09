﻿using System;
using System.Collections.Generic;
using Model.Core.Entity.Base;
using Model.Core.Interface.Entity;
using UnityEngine;

namespace Control.Model {
    public class EntitiesCreateHandler {

        private readonly Dictionary<Type, IEntityCreateListener> listeners;

        public EntitiesCreateHandler() {
            listeners = new Dictionary<Type, IEntityCreateListener>();

            EntityBase.StaticCreateEvent += EntityCreateHandler;
        }

        private void EntityCreateHandler(IEntity entity) {
            IEntityCreateListener createListener = Get(entity);
            if (createListener == null) {
                Debug.LogError($"EntityCreateListener not found for <{entity.GetType().Name}>");
                return;
            }

            createListener.OnCreate(entity);
        }

        private IEntityCreateListener Get(IEntity entity) {
            return listeners.GetValueOrDefault(entity.GetType());

        }

        public void AddListener<T>(IEntityCreateListener listener) where T : IEntity, new() {
            listeners.Add(typeof(T), listener);
        }

    }
}