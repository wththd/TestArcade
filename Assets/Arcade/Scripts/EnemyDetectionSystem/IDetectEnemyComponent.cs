using UnityEngine;

namespace Arcade.Scripts.EnemyDetectionSystem
{
    public interface IDetectEnemyComponent
    {
        float Range { get; }
        bool IsInRange(Vector3 firstPosition, Vector3 secondPosition, out float distance);
    }
}