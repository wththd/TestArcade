using UnityEngine;

namespace Arcade.Scripts.Configs
{
    [CreateAssetMenu(menuName = "Configs/GameplayConfig", fileName = "GameplayConfig")]
    public class GameplayConfig : ScriptableObject, IValidatable
    {
        [SerializeField] [Range(1, 30)] 
        private int enemyWinCount;
        [SerializeField]
        private int initialHealth;

        public int EnemyWinCount => enemyWinCount;
        public int InitialHealth => initialHealth;

        public void Validate()
        {
            if (initialHealth <= 0)
            {
                Debug.LogError("Incorrect initial health for player");
            }
        }
    }
}