using Asteroids.Framework.Entity;
using UnityEngine;

namespace Asteroids.Core.Actors.Player {
    public class Player : ColliderEntity<PlayerState, PlayerConfig>, IPlayer {

        public Vector3 WeaponWorldPosition => Transform.position + Transform.up * 0.2f;


        public override void Upd(float deltaTime) {
            // Moving
            if (State.Move) {
                if (State.inertialTime < 1) {
                    State.inertialTime = Mathf.Min(1, State.inertialTime + deltaTime * (1 / Config.AccelerationInertia));
                    State.inertialSpeed = Mathf.Lerp(0, Config.Speed, State.inertialTime);
                }
            } else {
                if (State.inertialTime > 0) {
                    State.inertialTime = Mathf.Max(0, State.inertialTime - deltaTime * (1 / Config.BrakingInertia));
                    State.inertialSpeed = Mathf.Lerp(0, Config.Speed, State.inertialTime);
                }
            }

            if (State.inertialTime > 0) {
                // transform.Translate(transform.up * (config.speed * deltaTime));
                Vector3 direction;
                if (State.Move) {
                    direction = Vector3.Lerp(State.lastDirection, Transform.up, deltaTime / Config.LeftOverInertia); // leftover inertia
                } else {
                    direction = State.lastDirection; // don't change direction without acceleration
                }
                State.lastDirection = direction * State.inertialTime;

                Vector3 position = Transform.position;
                position += direction * (State.inertialSpeed * deltaTime);
                Transform.position = position;
            }


            // Rotation
            if (Mathf.Abs(State.Rotate) > 0.01f) {
                Transform.Rotate(0, 0, Config.RotationSpeed * deltaTime * State.Rotate);
            }

            // Calculate speed
            Vector3 pos = Transform.position;
            State.speed = Vector3.Distance(State.lastPos, pos) / deltaTime;
            State.lastPos = pos;

        }

    }
}