using Asteroids.Framework.Common;
using UnityEngine;

namespace Asteroids.Core.World.Common.Config {
    [CreateAssetMenu(menuName = "Configs/Screen Config")]
    public class ScreenConfig : ScriptableObject, IConfig {

        [field: Space]
        [field: SerializeField] public Vector2 ViewportOutsideBorders { get; private set; } = new(-0.02f, 1.02f);

        [field: Tooltip("outermost boundary for for infinity screen translation \n\n Must be bigger than spawn offset")]
        [field: SerializeField] public float ScreenInfinityOutsideOffset { get; private set; } = 0.3f;

        [field: Tooltip("outermost boundary for entities - used for spawn entities \n\n Must be smaller than infinity offset")]
        [field: SerializeField] public float ScreenSpawnOutsideOffset { get; private set; } = 0.25f;

    }
}