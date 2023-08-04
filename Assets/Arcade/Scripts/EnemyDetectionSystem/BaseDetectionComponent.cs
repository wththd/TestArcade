using UnityEngine;

namespace Arcade.Scripts.EnemyDetectionSystem
{
    public abstract class BaseDetectionComponent : MonoBehaviour, IDetectEnemyComponent
    {
        public float Range { get; private set; }
        public abstract bool IsInRange(Vector3 firstPosition, Vector3 secondPosition, out float distance);

        public void SetRange(float range)
        {
            Range = range;
        }
    }
}