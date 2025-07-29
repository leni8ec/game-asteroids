using Asteroids.Framework.Common;
using UnityEngine;

namespace Asteroids.Core.World.Audio {
    [CreateAssetMenu(menuName = "Configs/Sounds Catalog")]
    public class SoundsCatalog : ScriptableObject, ICatalog, IConfig {
        [Space]
        public AudioClip playerMove;
        public AudioClip playerExplosion;
        [Space]
        public AudioClip fire1;
        public AudioClip fire2;
        [Space]
        public AudioClip ufoLarge;
        public AudioClip ufoSmall;
        [Space]
        public AudioClip explosionLarge;
        public AudioClip explosionMedium;
        public AudioClip explosionSmall;
        [Space]
        public AudioClip extraShip;
        [Space]
        public AudioClip wavyBit1;
        public AudioClip wavyBit2;
    }
}