using UnityEngine;

namespace Arcade.Scripts.PathPrediction
{
    public interface IPathPredictor
    {
        Vector3 Predict(float targetSpeed, Vector2 targetPosition, float bulletSpeed, Vector2 weaponPosition);
    }
}