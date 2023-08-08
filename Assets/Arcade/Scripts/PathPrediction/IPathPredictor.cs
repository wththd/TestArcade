using UnityEngine;

namespace Arcade.Scripts.PathPrediction
{
    public interface IPathPredictor
    {
        float MinYPosition { get; set; }
        bool Predict(float targetSpeed, Vector2 targetPosition, float bulletSpeed, Vector2 weaponPosition, out Vector3 calculatedPosition);
    }
}