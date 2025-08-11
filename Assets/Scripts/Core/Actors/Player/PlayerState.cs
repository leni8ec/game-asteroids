using Asteroids.Core.Actors.Common;
using Asteroids.Framework.Reactive;
using UnityEngine;

namespace Asteroids.Core.Actors.Player {

    public interface IPlayerState : IEntityViewState {

        /// <summary>
        /// Move state
        /// <br/>
        /// <br/> • false: idle
        /// <br/> • true: movement
        /// </summary>
        IReactiveFlag Move { get; }
        /// <summary>
        /// Rotate state
        /// <br/>
        /// <br/> • 0: idle
        /// <br/> • 1: left rotation
        /// <br/> • -1: right rotation
        /// </summary>
        float Rotate { get; }

        float InertialSpeed { get; }
        float InertialTime { get; }
        Vector3 LastDirection { get; }
        Vector3 LastPos { get; }
        float Speed { get; }
        Vector3 WeaponWorldPosition { get; }

    }


    public class PlayerState : EntityState, IPlayerState {

        [field: SerializeField] public ReactiveFlag move = new();
        public IReactiveFlag Move => move;

        [field: SerializeField] public float Rotate { get; set; }

        [field: Space]
        [field: SerializeField] public float InertialSpeed { get; set; }
        [field: SerializeField] public float InertialTime { get; set; }
        [field: SerializeField] public Vector3 LastDirection { get; set; }
        [field: SerializeField] public Vector3 LastPos { get; set; }
        [field: SerializeField] public float Speed { get; set; }
        [field: SerializeField] public Vector3 WeaponWorldPosition { get; set; }


        protected override void OnReset() {
            move.ResetQuietly();
            Rotate = default;
            InertialSpeed = default;
            InertialTime = default;
            LastDirection = default;
            LastPos = default;
            Speed = default;
            WeaponWorldPosition = default;
        }


    #region Leftovers

        // Reference reactive property - to show directly in inspector (without spoiler)
        // [SerializeField]
        // private bool stateVal;
        // public ReferenceReactiveProperty<bool> stateValRx;
        //
        // private bool GetValue() {
        //     return stateVal;
        // }
        //
        // private void Awake() {
        //     stateValRx = new ReferenceReactiveProperty<bool>(() => stateVal, value => stateVal = value);
        // }

    #endregion


    }


}