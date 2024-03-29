﻿using Model.Data.Containers;
using Model.Data.State.Base;
using Model.Data.Unity.Config.Base;
using Model.Entity.Interface;
using UnityEngine;

namespace Model.Entity.Base {
    public abstract class ColliderEntity<TState, TConfig> : Entity<TState, TConfig>, ICollider
        where TState : EntityState, new()
        where TConfig : IConfigData, IColliderRadiusContainer {

        public float ColliderRadius => Config.ColliderRadius;
        public Vector3 Pos => Transform.position;

    }
}