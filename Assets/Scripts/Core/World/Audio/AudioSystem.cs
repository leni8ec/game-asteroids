using Asteroids.Core.Actors.Enemies.Asteroid;
using Asteroids.Core.Actors.Enemies.Ufo;
using Asteroids.Core.Actors.Player;
using Asteroids.Core.World.Entities.State;
using Asteroids.Core.World.Game;
using Asteroids.Core.World.Players.Weapons;
using Asteroids.Framework.Systems;
using Asteroids.Framework.Systems.Behaviour;
using JetBrains.Annotations;
using UnityEngine;

namespace Asteroids.Core.World.Audio {
    [UsedImplicitly]
    public class AudioSystem : SystemBase, IAudioSystem, IStartSystem {
        private SoundsCatalog Catalog { get; }
        private IAudioAdapter Adapter { get; }

        public WeaponState WeaponState { get; }
        public EntitiesState Entities { get; }

        public AudioSystem(SoundsCatalog catalog, IAudioAdapter audioAdapter,
            WeaponState weaponState, GameState gameState, EntitiesState entities
        ) {
            Catalog = catalog;
            Adapter = audioAdapter;

            WeaponState = weaponState;
            Entities = entities;

            // Game state events
            RegisterSystemActivityFlag(gameState.LevelActiveFlag);
        }

        public void Start() {
            // Weapon events
            WeaponState.Fire1Event += () => PlaySound(Catalog.Fire1);
            WeaponState.Fire2Event += () => PlaySound(Catalog.Fire2);

            // Enemy events
            Entities.KillEvent += entity => {
                switch (entity) {
                    case Player:
                        PlaySound(Catalog.PlayerExplosion, true); break;
                    case Asteroid asteroid:
                        switch (asteroid.Size) {
                            case AsteroidSize.Large: PlaySound(Catalog.ExplosionLarge); break;
                            case AsteroidSize.Medium: PlaySound(Catalog.ExplosionMedium); break;
                            case AsteroidSize.Small: PlaySound(Catalog.ExplosionSmall); break;
                        }
                        break;
                    case Ufo:
                        PlaySound(Catalog.ExplosionMedium); break;
                }
            };
        }

        private void PlaySound(AudioClip clip, bool forced = false) {
            if (!forced && !SystemEnabled) return;

            Adapter.PlaySound(clip);
        }

    }
}