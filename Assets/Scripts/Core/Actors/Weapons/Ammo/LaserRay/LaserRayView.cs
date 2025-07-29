using Asteroids.Core.Actors.Weapons.Arms.Laser;
using Asteroids.Framework.Entity;
using UnityEngine;

namespace Asteroids.Core.Actors.Weapons.Ammo.LaserRay {
    public class LaserRayView : EntityView<LaserRayState, LaserConfig> {
        [SerializeField] private Transform scaledTransform;
        [SerializeField] private SpriteRenderer laserSprite;

        protected override void SubscribeEvents() {
            State.Active.Enabled += FireHandle;
        }

        private void FireHandle() {
            // Set laser scale (visual)
            Vector3 scale = scaledTransform.localScale;
            scale.y = Config.maxDistance;
            scaledTransform.localScale = scale;
        }

        private void Update() {
            Color color = laserSprite.color;
            color.a = Mathf.Max(0, State.duration / Config.duration);
            laserSprite.color = color;
        }

    }
}