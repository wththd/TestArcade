using UnityEngine;

namespace Arcade.Scripts.InputSystem
{
    public interface IInputController
    {
        bool IsMoveButtonPressed();
        Vector2 GetMoveDirection();
    }
}