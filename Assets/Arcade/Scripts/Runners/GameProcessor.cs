using System;
using Arcade.Scripts.EnemySpawnSystem;
using Arcade.Scripts.HealthSystem;
using Arcade.Scripts.PauseSystem;
using Arcade.Scripts.Player;
using Arcade.Scripts.WinCondition;
using UnityEngine;
using Zenject;

namespace Arcade.Scripts.Runners
{
    public class GameProcessor : ITickable, IDisposable, IPausable
    {
        private IEnemySpawner enemySpawner;
        private IPauseController pauseController;
        private bool playing;
        private PlayerController playerController;
        private IWinConditionChecker winConditionChecker;

        public event Action GameWon;
        public event Action GameLost;

        public GameProcessor(IEnemySpawner enemySpawner, IPauseController pauseController, IWinConditionChecker winConditionChecker)
        {
            this.enemySpawner = enemySpawner;
            this.pauseController = pauseController;
            this.winConditionChecker = winConditionChecker;
            
            pauseController.AddPausable(this);
        }

        public void Start(PlayerController playerController)
        {
            this.playerController = playerController;
            playing = true;
        }
        
        public void Tick()
        {
            if (!playing)
            {
                return;
            }
            
            if (enemySpawner.CanSpawn())
            {
                var enemy = enemySpawner.Spawn();
                enemy.SetDamageAction(DamagePlayer);
                enemy.SetDieAction(ProcessEnemyDieAction);
            }
        }

        private void ProcessEnemyDieAction()
        {
            winConditionChecker.ProcessEvent(EnemyDiedWinCondition.EnemyDieEventName);
            if (winConditionChecker.IsGameWon())
            {
                playing = false;
                GameWon?.Invoke();
            }
        }

        private void DamagePlayer()
        {
            playerController.GetComponent<IHealth>().DealDamage(1);
        }

        public void Pause()
        {
            playing = false;
        }

        public void Resume()
        {
            playing = true;
        }

        public void Dispose()
        {
            pauseController.RemovePausable(this);
        }

        public void LooseGame()
        {
            playing = false;
            GameLost?.Invoke();
        }
    }
}