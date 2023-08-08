using UnityEngine;

namespace Arcade.Scripts.PathPrediction
{
    public class PathPredictor : IPathPredictor
    {
        public float MinYPosition { get; set; }

        public bool Predict(float targetSpeed, Vector2 targetPosition, float bulletSpeed, Vector2 weaponPosition, out Vector3 calculatedPosition)
        {
            var a = targetSpeed * targetSpeed - bulletSpeed * bulletSpeed;
            var b = 2 * (targetSpeed * (targetPosition.y - weaponPosition.y));
            var c = (targetPosition.x - weaponPosition.x) * (targetPosition.x - weaponPosition.x) +
                    (targetPosition.y - weaponPosition.y) * (targetPosition.y - weaponPosition.y);
            var disc = b * b - 4 * a * c;

            if (disc < 0)
            {
                Debug.LogError("No possible hit!");
                calculatedPosition = Vector3.negativeInfinity;
                return false;
            }

            var t1 = (-b + Mathf.Sqrt(disc)) / (2 * a);
            var t2 = (-b - Mathf.Sqrt(disc)) / (2 * a);
            var t = Mathf.Max(t1, t2);
            var aimX = targetPosition.x;
            var aimY = targetPosition.y + targetSpeed * t;
            
            calculatedPosition = new Vector3(aimX, aimY, 0);
            return calculatedPosition.y > MinYPosition;
        }
    }
}