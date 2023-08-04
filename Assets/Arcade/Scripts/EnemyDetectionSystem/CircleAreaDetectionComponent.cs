using System;
using UnityEngine;

namespace Arcade.Scripts.EnemyDetectionSystem
{
    public class CircleAreaDetectionComponent : BaseDetectionComponent
    {
        public override bool IsInRange(Vector3 firstPosition, Vector3 secondPosition, out float distance)
        {
            distance = Vector3.Distance(secondPosition, firstPosition);
            return distance < Range;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, Range);
        }
    }
}