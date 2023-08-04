using UnityEngine;

namespace Arcade.Scripts.InputSystem
{
    public class EnemyInputController : IInputController
    {
        public bool IsMoveButtonPressed()
        {
            return true;
        }

        public Vector2 GetMoveDirection()
        {
            return Vector2.down;
        }
    }
}