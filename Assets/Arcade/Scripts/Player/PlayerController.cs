using System;
using Arcade.Scripts.Enemy;
using Arcade.Scripts.EnemyDetectionSystem;
using Arcade.Scripts.EnemySpawnSystem;
using Arcade.Scripts.HealthSystem;
using Arcade.Scripts.MoveSystem;
using Arcade.Scripts.PathPrediction;
using Arcade.Scripts.PauseSystem;
using Arcade.Scripts.WeaponSystem;
using UnityEngine;
using Zenject;

namespace Arcade.Scripts.Player
{
    public class PlayerController : MonoBehaviour, IPausable
    {
        private IPauseController pauseController;
        [SerializeField] 
        private BaseMoveComponent playerMoveComponent;
        [SerializeField] 
        private BaseDetectionComponent detectionComponent;
        [SerializeField] 
        private BaseFireComponent fireComponent;
        [SerializeField] 
        private PlayerHealthComponent healthComponent;

        private IEnemySpawner enemySpawner;
        private EnemyController currentTarget;
        private IPathPredictor pathPredictor;
        private float speed;

        private Action<int> healthChangedAction;
        private Action playerDiedAction;

        [Inject]
        private void Inject(float range, float fireRate, int damage, float bulletSpeed, float playerSpeed, int playerHealth, IPauseController pauseController, IEnemySpawner enemySpawner, IPathPredictor pathPredictor)
        {
            this.pauseController = pauseController;
            this.enemySpawner = enemySpawner;
            this.pathPredictor = pathPredictor;
            
            pauseController.AddPausable(this);

            speed = playerSpeed;
            playerMoveComponent.SetSpeed(playerSpeed);
            detectionComponent.SetRange(range);
            fireComponent.Init(bulletSpeed, fireRate, damage);
            
            healthComponent.Setup(playerHealth);
            healthComponent.Died += OnDied;
            healthComponent.HealthChanged += OnHealthChanged;
        }

        private void OnHealthChanged(int health)
        {
            healthChangedAction?.Invoke(health);
        }

        private void OnDied()
        {
            DestroySelf();
            playerDiedAction.Invoke();
        }

        private void Update()
        {
            if (detectionComponent != null)
            {
                DetectClosestTarget();
            }

            if (fireComponent != null)
            {
                ShootIfNeeded();
            }
        }

        private void DetectClosestTarget()
        {
            var minDistance = float.MaxValue;
            foreach (var enemy in enemySpawner.Enemies)
            {
                if (detectionComponent.IsInRange(transform.position, enemy.transform.position, out var distance))
                {
                    if (distance < minDistance)
                    {
                        currentTarget = enemy;
                        minDistance = distance;
                    }
                }
                
            }
        }

        private void ShootIfNeeded()
        {
            if (currentTarget != null)
            {
                if (fireComponent.CanLaunch())
                {
                    var direction = pathPredictor.Predict(-currentTarget.Speed, currentTarget.transform.position,
                        fireComponent.ProjectileSpeed, fireComponent.WeaponPosition);
                    fireComponent.Launch(direction);
                }
            }
        }
        
        private void OnDestroy()
        {
            pauseController.RemovePausable(this);
        }

        private void DestroySelf()
        {
            Destroy(gameObject);
        }

        public void Pause()
        {
            playerMoveComponent.SetSpeed(0);
        }

        public void Resume()
        {
            playerMoveComponent.SetSpeed(speed);
        }

        public void SetDieAction(Action dieAction)
        {
            playerDiedAction = dieAction;
        }

        public void SetHealthChangeAction(Action<int> action)
        {
            healthChangedAction = action;
        }
    }
}