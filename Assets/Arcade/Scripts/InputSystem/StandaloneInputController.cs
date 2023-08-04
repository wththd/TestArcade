using UnityEngine;

namespace Arcade.Scripts.InputSystem
{
    public class StandaloneInputController : IInputController
    {
        public bool IsMoveButtonPressed()
        {
            return Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) ||
                   Input.GetKey(KeyCode.W);
        }

        public Vector2 GetMoveDirection()
        {
            var result = Vector2.zero;
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                result.x -= 1;
            }

            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                result.y -= 1;
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                result.x += 1;
            }

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                result.y += 1;
            }

            return result;
        }
    }
}