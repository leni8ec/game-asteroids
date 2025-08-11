using System;
using System.ComponentModel;

namespace Asteroids.Core.Actors.Enemies.Asteroid {
    public class Asteroid : Enemy<AsteroidState, AsteroidConfig>, IAsteroid {
        public delegate void ExplosionEvent(Asteroid asteroid);
        public event ExplosionEvent Explosion;

        public float DestroyedFragments => Config.DestroyFragments;
        public AsteroidSize Size => Config.Size;

        public override void Upd(float deltaTime) {
            Transform.Translate(State.direction * (Config.Speed * deltaTime));
        }

        protected override void OnKill() {
            Explosion?.Invoke(this);
        }

    }

    public enum AsteroidSize {
        Large,
        Medium,
        Small
    }

    public static class AsteroidSizeExtensions {
        /// Gets the next asteroid size in decreasing order
        public static AsteroidSize NextSmallerSize(this AsteroidSize size) {
            return size switch {
                AsteroidSize.Large => AsteroidSize.Medium,
                AsteroidSize.Medium => AsteroidSize.Small,
                AsteroidSize.Small => throw new InvalidEnumArgumentException("A small asteroid cannot be reduced in size"),
                _ => throw new ArgumentOutOfRangeException(nameof(size), size, null)
            };
        }
    }
}