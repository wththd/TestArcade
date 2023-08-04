using UnityEngine;

namespace Arcade.Scripts.EnemyDetectionSystem
{
    public class CircleAreaDetectionComponent : BaseDetectionComponent
    {
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, Range);
        }

        public override bool IsInRange(Vector3 firstPosition, Vector3 secondPosition, out float distance)
        {
            distance = Vector3.Distance(secondPosition, firstPosition);
            return distance < Range;
        }
    }
}