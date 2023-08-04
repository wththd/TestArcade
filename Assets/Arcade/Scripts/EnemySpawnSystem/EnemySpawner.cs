using System.Collections.Generic;
using Arcade.Scripts.Configs;
using Arcade.Scripts.Enemy;
using UnityEngine;

namespace Arcade.Scripts.EnemySpawnSystem
{
    public class EnemySpawner : IEnemySpawner
    {
        public List<EnemyController> Enemies { get; private set; }

        private EnemyInitialConfig enemyInitialConfig;
        private EnemyFactory enemyFactory;
        private EnemyTransformsConfig enemyTransformsConfig;
        private float lastSpawnTime;
        private float cooldown;

        public EnemySpawner(EnemyInitialConfig enemyInitialConfig, EnemyFactory enemyFactory, EnemyTransformsConfig enemyTransformsConfig)
        {
            this.enemyInitialConfig = enemyInitialConfig;
            this.enemyFactory = enemyFactory;
            this.enemyTransformsConfig = enemyTransformsConfig;

            Enemies = new List<EnemyController>();
        }

        public bool CanSpawn()
        {
            return Time.unscaledTime - lastSpawnTime > cooldown;
        }

        public EnemyController Spawn()
        {
            RandomizeEnemyValues(out var speed, out var parent, out cooldown, out var sprite);
            var enemy = enemyFactory.Create(speed, enemyInitialConfig.EnemyHealth, sprite);
            enemy.transform.SetParent(parent);
            enemy.transform.localPosition = Vector3.zero;
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
            parent = enemyTransformsConfig.EnemiesTransforms[Random.Range(0, enemyTransformsConfig.EnemiesTransforms.Count)];
            sprite = enemyInitialConfig.EnemySprites[Random.Range(0, enemyInitialConfig.EnemySprites.Count)];
        }
    }
}