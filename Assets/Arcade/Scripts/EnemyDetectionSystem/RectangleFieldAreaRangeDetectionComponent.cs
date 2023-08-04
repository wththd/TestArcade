using System;
using UnityEngine;

namespace Arcade.Scripts.EnemyDetectionSystem
{
    public class RectangleFieldAreaRangeDetectionComponent : BaseDetectionComponent
    {
        public override bool IsInRange(Vector3 firstPosition, Vector3 secondPosition, out float distance)
        {
            distance = Math.Abs(secondPosition.y - firstPosition.y);
            return distance < Range;
        }
    }
}