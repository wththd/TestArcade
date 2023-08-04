using Arcade.Scripts.InputSystem;
using UnityEngine;

namespace Arcade.Scripts.MoveSystem
{
    public class BaseMoveComponent : MonoBehaviour
    {
        protected Transform cachedTransform;
        protected Vector2 currentSpeed;
        protected IInputController inputController;
        public float Speed { get; private set; }

        protected virtual void Awake()
        {
            cachedTransform = GetComponent<Transform>();
        }

        protected virtual void Update()
        {
            UpdateInputSpeed();
            UpdateMove();
            UpdatePosition();
        }

        protected virtual void UpdateInputSpeed()
        {
            if (inputController.IsMoveButtonPressed())
                currentSpeed = inputController.GetMoveDirection();
            else
                currentSpeed = Vector2.zero;
        }

        protected virtual void UpdateMove()
        {
        }


        protected virtual void UpdatePosition()
        {
            if (currentSpeed == Vector2.zero || Speed == 0) return;

            var currentPosition = cachedTransform.position;
            var targetPosition = currentSpeed.normalized * (Speed * Time.deltaTime);
            currentPosition += new Vector3(targetPosition.x, targetPosition.y, currentPosition.z);
            cachedTransform.position = currentPosition;
        }

        public void SetSpeed(float speed)
        {
            Speed = speed;
        }
    }
}