using Asteroids.Core.Actors.Common;
using UnityEngine;

namespace Asteroids.Core.Actors.Weapons.Ammo.Bullet {

    public interface IBulletState : IEntityViewState {
        float Lifetime { get; }
    }


    public class BulletState : EntityState, IBulletState {

        [field: SerializeField] public float Lifetime { get; internal set; }

        protected override void OnReset() {
            Lifetime = default;
        }

    }

}