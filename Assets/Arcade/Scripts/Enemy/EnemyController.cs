using System;
using Arcade.Scripts.EventListeners;
using Arcade.Scripts.HealthSystem;
using Arcade.Scripts.MoveSystem;
using Arcade.Scripts.PauseSystem;
using UnityEngine;
using Zenject;

namespace Arcade.Scripts.Enemy
{
    public class EnemyController : MonoBehaviour, IPausable
    {
        public event Action<EnemyController> Destroyed;
        
        [SerializeField] 
        private BaseMoveComponent moveComponent;
        [SerializeField] 
        private EnemyHealthComponent healthComponent;
        [SerializeField] 
        private Trigger2DEventListener triggerListener;

        [SerializeField] 
        private SpriteRenderer spriteRenderer;

        private float configSpeed;
        private IPauseController pauseController;

        public float Speed => moveComponent.Speed;

        private Action playerDamageAction;
        private Action enemyDieAction;
        
        [Inject]
        private void Inject(float speed, int health, Sprite enemySprite, IPauseController pauseController)
        {
            if (moveComponent != null)
            {
                moveComponent.SetSpeed(speed);
                configSpeed = speed;
            }

            if (healthComponent != null)
            {
                healthComponent.Setup(health);
                healthComponent.Died += HealthComponentOnDied;
            }
            
            triggerListener.OnTriggerEnter += OnTriggerEntered;
            spriteRenderer.sprite = enemySprite;

            this.pauseController = pauseController;
            pauseController.AddPausable(this);
        }

        private void OnTriggerEntered(Collider2D other)
        {
            if (other.CompareTag("PlayerMoveAreaBorder"))
            {
                DestroySelf();
                playerDamageAction?.Invoke();
            }
        }

        private void HealthComponentOnDied()
        {
            enemyDieAction?.Invoke();
            DestroySelf();
        }

        public void SetDamageAction(Action action)
        {
            playerDamageAction = action;
        }

        public void SetDieAction(Action action)
        {
            enemyDieAction = action;
        }

        public void Pause()
        {
            if (moveComponent != null)
            {
                moveComponent.SetSpeed(0);
            }
        }

        public void Resume()
        {
            if (moveComponent != null)
            {
                moveComponent.SetSpeed(configSpeed);
            }
        }

        private void OnDestroy()
        {
            pauseController.RemovePausable(this);
            triggerListener.OnTriggerEnter -= OnTriggerEntered;
        }

        private void DestroySelf()
        {
            Destroyed?.Invoke(this);
            Destroy(gameObject);
        }
    }
}