using Asteroids.Framework.Common;
using UnityEngine;

namespace Asteroids.Core.World.Common.Config {
    [CreateAssetMenu(menuName = "Configs/Level Config", order = -1000)]
    public class LevelConfig : ScriptableObject, IConfig {

        [field: Space]
        [field: Tooltip("Max asteroids count (in any sizes)")]
        [field: SerializeField] public int AsteroidsLimit { get; private set; } = 20;
        [field: Tooltip("Max ufos count (in any sizes)")]
        [field: SerializeField] public int UfosLimit { get; private set; } = 3;

        [field: Space]
        [field: Tooltip("Count in sec")]
        [field: SerializeField] public float AsteroidsSpawnRate { get; private set; } = 3;
        [field: Tooltip("Count in sec")]
        [field: SerializeField] public float UfoSpawnRate { get; private set; } = 0.1f;

    }
}