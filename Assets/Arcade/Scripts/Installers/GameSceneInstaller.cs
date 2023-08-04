using System;
using Arcade.Scripts.Configs;
using Arcade.Scripts.Containers;
using Arcade.Scripts.Enemy;
using Arcade.Scripts.EnemySpawnSystem;
using Arcade.Scripts.InputSystem;
using Arcade.Scripts.PathPrediction;
using Arcade.Scripts.PauseSystem;
using Arcade.Scripts.Player;
using Arcade.Scripts.Runners;
using Arcade.Scripts.WeaponSystem;
using Arcade.Scripts.WinCondition;
using UnityEngine;
using Zenject;

namespace Arcade.Scripts.Installers
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField] private GameplayPrefabContainer gameplayPrefabContainer;

        [SerializeField] private Transform playerTransformPoint;

        [SerializeField] private EnemyTransformsConfig enemyTransforms;

        public override void InstallBindings()
        {
            Container.BindInstance(gameplayPrefabContainer);
            Container.BindInstance(enemyTransforms);
            Container.Bind<IInputController>().To<StandaloneInputController>().AsSingle();
            Container.Bind<IPauseController>().To<PauseController>().AsSingle();
            Container.Bind<IEnemySpawner>().To<EnemySpawner>().AsSingle();
            Container.Bind(typeof(GameProcessor), typeof(ITickable), typeof(IDisposable)).To<GameProcessor>()
                .AsSingle();
            Container.Bind<IPathPredictor>().To<PathPredictor>().AsSingle();
            Container.Bind<IWinConditionChecker>().To<WinConditionChecker>().AsSingle();

            InstallFactories();
        }

        private void InstallFactories()
        {
            Container.BindFactory<float, float, int, float, float, int, PlayerController, PlayerFactory>()
                .FromComponentInNewPrefab(gameplayPrefabContainer.PlayerControllerPrefab)
                .UnderTransform(playerTransformPoint);
            Container.BindFactory<float, int, Sprite, EnemyController, EnemyFactory>()
                .FromComponentInNewPrefab(gameplayPrefabContainer.EnemyControllerPrefab);
            Container.BindFactory<Vector3, Vector3, float, int, Bullet, BulletFactory>()
                .FromComponentInNewPrefab(gameplayPrefabContainer.BulletPrefab)
                .UnderTransformGroup("Bullets");
        }
    }
}