using UnityEngine;

namespace Asteroids.Framework.Entity {
    public interface ICollider : IEntity {
        public float ColliderRadius { get; }
        public Vector3 Pos { get; }
    }
}