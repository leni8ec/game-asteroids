﻿using UnityEngine;

namespace Core.Interface.Objects {
    public interface ICollider {
        public float ColliderRadius { get; }
        public Vector3 Pos { get; }
    }
}