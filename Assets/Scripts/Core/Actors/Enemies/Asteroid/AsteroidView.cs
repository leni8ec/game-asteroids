using Asteroids.Framework.Entity;
using UnityEngine;
using Random = System.Random;

namespace Asteroids.Core.Actors.Enemies.Asteroid {
    public class AsteroidView : EntityView<AsteroidState, AsteroidConfig> {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Sprite[] sprites;

        protected override void SubscribeEvents() { }

        private void Start() {
            int index = new Random().Next(sprites.Length);
            spriteRenderer.sprite = sprites[index];
        }

    }
}