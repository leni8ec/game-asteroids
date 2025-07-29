using Asteroids.Framework.Common;
using UnityEngine;

namespace Asteroids.Core.World.Audio {
    [CreateAssetMenu(menuName = "Configs/Sounds Catalog")]
    public class SoundsCatalog : ScriptableObject, ICatalog, IConfig {
        [field: Space]
        [field: SerializeField] public AudioClip PlayerMove { get; private set; }
        [field: SerializeField] public AudioClip PlayerExplosion { get; private set; }
        [field: Space]
        [field: SerializeField] public AudioClip Fire1 { get; private set; }
        [field: SerializeField] public AudioClip Fire2 { get; private set; }
        [field: Space]
        [field: SerializeField] public AudioClip UfoLarge { get; private set; }
        [field: SerializeField] public AudioClip UfoSmall { get; private set; }
        [field: Space]
        [field: SerializeField] public AudioClip ExplosionLarge { get; private set; }
        [field: SerializeField] public AudioClip ExplosionMedium { get; private set; }
        [field: SerializeField] public AudioClip ExplosionSmall { get; private set; }
        [field: Space]
        [field: SerializeField] public AudioClip ExtraShip { get; private set; }
        [field: Space]
        [field: SerializeField] public AudioClip WavyBit1 { get; private set; }
        [field: SerializeField] public AudioClip WavyBit2 { get; private set; }
    }
}