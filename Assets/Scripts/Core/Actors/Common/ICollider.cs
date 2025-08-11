using Asteroids.Core.Actors.Common.Containers;
using UnityEngine;

namespace Asteroids.Core.Actors.Common {
    public interface ICollider : IEntity, IColliderRadiusContainer {

        public Vector3 Pos { get; }

    }
}