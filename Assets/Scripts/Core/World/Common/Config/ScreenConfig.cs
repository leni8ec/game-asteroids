using Asteroids.Framework.Common;
using UnityEngine;

namespace Asteroids.Core.World.Common.Config {
    [CreateAssetMenu(menuName = "Configs/Screen Config")]
    public class ScreenConfig : ScriptableObject, IConfig {

        [Space]
        public Vector2 viewportOutsideBorders = new(-0.02f, 1.02f);

        [Tooltip("outermost boundary for for infinity screen translation \n\n Must be bigger than spawn offset")]
        public float screenInfinityOutsideOffset = 0.3f;
        [Tooltip("outermost boundary for entities - used for spawn entities \n\n Must be smaller than infinity offset")]
        public float screenSpawnOutsideOffset = 0.25f;

    }
}