using Asteroids.Framework.Entity;
using Asteroids.Framework.Reactive;
using UnityEngine;

namespace Asteroids.Core.Actors.Player {
    public class PlayerState : EntityState {


    #region Input state

        /// <summary>
        /// Move state
        /// <br/>
        /// <br/> • false: idle
        /// <br/> • true: movement
        /// </summary>
        [field: SerializeField]
        public ReactiveProperty<bool> Move { get; private set; } = new();

        /// <summary>
        /// Rotate state
        /// <br/>
        /// <br/> • 0: not rotation
        /// <br/> • 1: left rotation
        /// <br/> • -1: right rotation
        /// </summary>
        [field: SerializeField]
        public ReactiveProperty<int> Rotate { get; private set; } = new();

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


        [Space]
        public float inertialSpeed;
        public float inertialTime;

        public Vector3 lastDirection;
        public Vector3 lastPos;

        public float speed;

        public Vector3 weaponWorldPosition;


        protected override void OnReset() {
            Move.ResetQuietly();
            Rotate.ResetQuietly();
            inertialSpeed = default;
            inertialTime = default;
            lastDirection = default;
            lastPos = default;
            speed = default;
            weaponWorldPosition = default;
        }

    }
}