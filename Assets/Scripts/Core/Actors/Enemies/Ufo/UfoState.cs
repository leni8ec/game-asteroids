using System;
using Asteroids.Core.Actors.Common;
using Asteroids.Framework.Reactive;
using UnityEngine;

namespace Asteroids.Core.Actors.Enemies.Ufo {

    public interface IUfoState : IEntityViewState {
        ReactiveFlag Hunting { get; }
        float HuntCountdown { get; }
        float Speed { get; }
        EntityBase Target { get; }
    }


    public class UfoState : EntityState, IUfoState {

        public ReactiveFlag hunting = new();
        public ReactiveFlag Hunting => hunting;

        [field: SerializeField] public float HuntCountdown { get; set; }
        [field: SerializeField] public float Speed { get; set; }
        [field: SerializeField] public EntityBase Target { get; set; }

        protected override void OnReset() {
            hunting.ResetQuietly();
            HuntCountdown = default;
            Speed = default;
            Target = default;
        }

    }
}