using UnityEngine;

namespace Asteroids.Core.World.Camera {
    public class UnityCameraAdapter : MonoBehaviour, ICameraAdapter {

        [SerializeField] private UnityEngine.Camera mainCamera;

        public float ScreenWidth => UnityEngine.Screen.width;
        public float ScreenHeight => UnityEngine.Screen.height;

        public Vector3 ScreenToWorldPoint(Vector3 screenPoint) {
            return mainCamera.ScreenToWorldPoint(screenPoint);
        }

        public Rect GetWorldLimits(float screenOffset) {
            Vector2 min = ScreenToWorldPoint(Vector3.zero);
            Vector2 max = ScreenToWorldPoint(new Vector3(ScreenWidth, ScreenHeight));
            Rect limits = new(min.x - screenOffset, min.y - screenOffset, max.x - min.x + screenOffset * 2, max.y - min.y + screenOffset * 2);
            return limits;
        }


    }
}