using Arcade.Scripts.Configs;
using Arcade.Scripts.PauseSystem;
using Arcade.Scripts.Player;
using Arcade.Scripts.UI;
using UnityEngine;
using Zenject;

namespace Arcade.Scripts.Runners
{
    public class GameplaySceneRunner : MonoBehaviour
    {
        [SerializeField] private GameplayScreen gameplayScreen;

        [SerializeField] private GameEndScreen gameEndScreen;

        private GameplayConfig gameplayConfig;
        private GameProcessor gameProcessor;
        private IPauseController pauseController;

        private PlayerController player;
        private PlayerConfig playerConfig;
        private PlayerFactory playerFactory;

        private void Awake()
        {
            player = playerFactory.Create(playerConfig.PlayerFireRange, playerConfig.PlayerFireSpeed,
                playerConfig.PlayerDamage, playerConfig.PlayerBulletSpeed, playerConfig.PlayerSpeed,
                gameplayConfig.InitialHealth);
            player.SetHealthChangeAction(OnHealthChanged);
            player.SetDieAction(OnPlayerDied);
            gameProcessor.Start(player);
            gameplayScreen.gameObject.SetActive(true);
        }

        private void OnDestroy()
        {
            gameProcessor.Dispose();
            gameProcessor.GameWon -= OnGameWon;
        }

        [Inject]
        private void Inject(PlayerFactory playerFactory, GameplayConfig gameplayConfig, GameProcessor gameProcessor,
            PlayerConfig playerConfig, IPauseController pauseController)
        {
            this.playerFactory = playerFactory;
            this.gameProcessor = gameProcessor;
            this.playerConfig = playerConfig;
            this.pauseController = pauseController;
            this.gameplayConfig = gameplayConfig;

            gameplayScreen.SetHealth(gameplayConfig.InitialHealth);
            gameProcessor.GameWon += OnGameWon;
        }

        private void OnGameWon()
        {
            EndGame(true);
        }

        private void OnHealthChanged(int health)
        {
            gameplayScreen.SetHealth(health);
        }

        private void OnPlayerDied()
        {
            gameProcessor.LooseGame();
            EndGame(false);
        }

        private void EndGame(bool result)
        {
            gameEndScreen.SetResult(result);
            gameplayScreen.gameObject.SetActive(false);
            gameEndScreen.gameObject.SetActive(true);
            pauseController.Pause();
        }
    }
}