using Asteroids.Framework.Common;
using UnityEngine;

namespace Asteroids.Core.World.Common.Config {
    [CreateAssetMenu(menuName = "Configs/Level Config", order = -1000)]
    public class LevelConfig : ScriptableObject, IConfig {

        [Tooltip("Max asteroids count (in any sizes)")]
        public int asteroidsLimit = 20;
        [Tooltip("Max ufos count (in any sizes)")]
        public int ufosLimit = 3;

        [Space]
        [Tooltip("Count in sec")]
        public float asteroidsSpawnRate = 3;
        [Tooltip("Count in sec")]
        public float ufoSpawnRate = 0.1f;

    }
}