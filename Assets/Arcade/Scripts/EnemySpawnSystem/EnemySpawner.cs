using System.Collections.Generic;
using Arcade.Scripts.Configs;
using Arcade.Scripts.Enemy;
using UnityEngine;

namespace Arcade.Scripts.EnemySpawnSystem
{
    public class EnemySpawner : IEnemySpawner
    {
        private readonly EnemyFactory enemyFactory;

        private readonly EnemyInitialConfig enemyInitialConfig;
        private readonly EnemyTransformsConfig enemyTransformsConfig;
        private float cooldown;
        private float lastSpawnTime;

        public EnemySpawner(EnemyInitialConfig enemyInitialConfig, EnemyFactory enemyFactory,
            EnemyTransformsConfig enemyTransformsConfig)
        {
            this.enemyInitialConfig = enemyInitialConfig;
            this.enemyFactory = enemyFactory;
            this.enemyTransformsConfig = enemyTransformsConfig;

            Enemies = new List<EnemyController>();
        }

        public List<EnemyController> Enemies { get; }

        public bool CanSpawn()
        {
            return Time.unscaledTime - lastSpawnTime > cooldown;
        }

        public EnemyController Spawn()
        {
            RandomizeEnemyValues(out var speed, out var parent, out cooldown, out var sprite);
            var enemy = enemyFactory.Create(speed, enemyInitialConfig.EnemyHealth, sprite, parent);
            enemy.Destroyed += OnDestroyed;
            Enemies.Add(enemy);
            lastSpawnTime = Time.unscaledTime;
            return enemy;
        }

        private void OnDestroyed(EnemyController enemy)
        {
            Enemies.Remove(enemy);
        }

        private void RandomizeEnemyValues(out float speed, out Transform parent, out float cooldown, out Sprite sprite)
        {
            speed = Random.Range(1, enemyInitialConfig.EnemyMaximumSpeed);
            cooldown = Random.Range(1, enemyInitialConfig.EnemySpawnCooldown);
            parent = enemyTransformsConfig.EnemiesTransforms[
                Random.Range(0, enemyTransformsConfig.EnemiesTransforms.Count)];
            sprite = enemyInitialConfig.EnemySprites[Random.Range(0, enemyInitialConfig.EnemySprites.Count)];
        }
    }
}