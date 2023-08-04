using UnityEngine;

namespace Arcade.Scripts.MoveBlockSystem
{
    public interface IPlayerMoveBorder
    {
        BlockState CurrentState { get; }
        void CalculateBlockState(Vector2 position, float radius);
        void ClearBlockState();
    }
}