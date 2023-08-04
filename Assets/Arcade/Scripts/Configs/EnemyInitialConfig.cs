using System.Collections.Generic;
using UnityEngine;

namespace Arcade.Scripts.Configs
{
    [CreateAssetMenu(menuName = "Configs/EnemyInitialConfig", fileName = "EnemyInitialConfig")]
    public class EnemyInitialConfig : ScriptableObject
    {
        [SerializeField] [Range(1, 5)] private float enemySpawnCooldown;

        [SerializeField] [Range(1, 5)] private float enemyMaximumSpeed;

        [SerializeField] private int enemyHealth;

        [SerializeField] private List<Sprite> enemySprites;

        public float EnemySpawnCooldown => enemySpawnCooldown;
        public float EnemyMaximumSpeed => enemyMaximumSpeed;
        public int EnemyHealth => enemyHealth;
        public List<Sprite> EnemySprites => enemySprites;
    }
}