using Asteroids.Framework.Common;
using UnityEngine;

namespace Asteroids.Core.World.Camera {
    public interface ICameraAdapter : IAdapter {

        Vector3 ScreenToWorldPoint(Vector3 screenPoint);

        Rect GetWorldLimits(float screenOffset);

        float ScreenWidth { get; }
        float ScreenHeight { get; }

    }
}