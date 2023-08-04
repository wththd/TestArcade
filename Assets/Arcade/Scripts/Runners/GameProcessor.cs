using System;
using Arcade.Scripts.EnemySpawnSystem;
using Arcade.Scripts.HealthSystem;
using Arcade.Scripts.PauseSystem;
using Arcade.Scripts.Player;
using Arcade.Scripts.WinCondition;
using Zenject;

namespace Arcade.Scripts.Runners
{
    public class GameProcessor : ITickable, IDisposable, IPausable
    {
        private readonly IEnemySpawner enemySpawner;
        private readonly IPauseController pauseController;
        private readonly IWinConditionChecker winConditionChecker;
        private PlayerController playerController;
        private bool playing;

        public GameProcessor(IEnemySpawner enemySpawner, IPauseController pauseController,
            IWinConditionChecker winConditionChecker)
        {
            this.enemySpawner = enemySpawner;
            this.pauseController = pauseController;
            this.winConditionChecker = winConditionChecker;

            pauseController.AddPausable(this);
        }

        public void Dispose()
        {
            pauseController.RemovePausable(this);
        }

        public void Pause()
        {
            playing = false;
        }

        public void Resume()
        {
            playing = true;
        }

        public void Tick()
        {
            if (!playing) return;

            if (enemySpawner.CanSpawn())
            {
                var enemy = enemySpawner.Spawn();
                enemy.SetDamageAction(DamagePlayer);
                enemy.SetDieAction(ProcessEnemyDieAction);
            }
        }

        public event Action GameWon;
        public event Action GameLost;

        public void Start(PlayerController playerController)
        {
            this.playerController = playerController;
            playing = true;
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

        public void LooseGame()
        {
            playing = false;
            GameLost?.Invoke();
        }
    }
}