using Arcade.Scripts.EventListeners;
using Arcade.Scripts.InputSystem;
using Arcade.Scripts.MoveBlockSystem;
using ModestTree;
using UnityEngine;
using Zenject;

namespace Arcade.Scripts.MoveSystem
{
    public class PlayerMoveComponent : BaseMoveComponent
    {
        [SerializeField] private BaseTriggerListener<Collider2D> triggerEventListener;

        private IPlayerMoveBorder moveBorder;

        protected override void Awake()
        {
            base.Awake();
            triggerEventListener ??= GetComponent<Trigger2DEventListener>();
            Assert.IsNotNull(triggerEventListener);
            triggerEventListener.OnTriggerEnter += OnTriggered;
            triggerEventListener.OnTriggerLeave += OnTriggerLeave;
        }

        private void OnDestroy()
        {
            triggerEventListener.OnTriggerEnter -= OnTriggered;
            triggerEventListener.OnTriggerLeave -= OnTriggerLeave;
        }

        [Inject]
        private void Inject(IInputController inputController)
        {
            this.inputController = inputController;
        }

        private void OnTriggered(Collider2D other)
        {
            if (other.CompareTag("PlayerMoveAreaBorder"))
            {
                moveBorder = other.GetComponent<IPlayerMoveBorder>();
                currentSpeed = Vector2.zero;
            }
        }

        private void OnTriggerLeave(Collider2D other)
        {
            if (other.CompareTag("PlayerMoveAreaBorder")) moveBorder = null;
        }


        protected override void UpdateMove()
        {
            if (moveBorder != null) UpdateSpeedAccordingBorders();
        }

        private void UpdateSpeedAccordingBorders()
        {
            const float radius = 0.286f;
            moveBorder.CalculateBlockState(cachedTransform.position, radius);
            if (moveBorder.CurrentState.HasFlag(BlockState.Down) && currentSpeed.y < 0) currentSpeed.y = 0;

            if (moveBorder.CurrentState.HasFlag(BlockState.Up) && currentSpeed.y > 0) currentSpeed.y = 0;

            if (moveBorder.CurrentState.HasFlag(BlockState.Left) && currentSpeed.x < 0) currentSpeed.x = 0;

            if (moveBorder.CurrentState.HasFlag(BlockState.Right) && currentSpeed.x > 0) currentSpeed.x = 0;
        }
    }
}