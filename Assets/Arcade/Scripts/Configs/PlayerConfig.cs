using UnityEngine;

namespace Arcade.Scripts.Configs
{
    [CreateAssetMenu(menuName = "Configs/PlayerConfig", fileName = "PlayerConfig")]
    public class PlayerConfig : ScriptableObject, IValidatable
    {
        [SerializeField]
        private float playerFireRange;
        [SerializeField] 
        private float playerFireSpeed;
        [SerializeField]
        private int playerDamage;
        [SerializeField] 
        private float playerBulletSpeed;
        [SerializeField]
        private float playerSpeed;

        public float PlayerFireRange => playerFireRange;
        public float PlayerFireSpeed => playerFireSpeed;
        public int PlayerDamage => playerDamage;
        public float PlayerBulletSpeed => playerBulletSpeed;
        public float PlayerSpeed => playerSpeed;
        
        public void Validate()
        {
            if (playerFireRange <= 0)
            {
                Debug.LogError($"{nameof(playerFireRange)} is not valid");
            }
            
            if (playerFireSpeed <= 0)
            {
                Debug.LogError($"{nameof(playerFireSpeed)} is not valid");
            }
            
            if (playerDamage <= 0)
            {
                Debug.LogError($"{nameof(playerDamage)} is not valid");
            }
            
            if (playerBulletSpeed <= 0)
            {
                Debug.LogError($"{nameof(playerBulletSpeed)} is not valid");
            }

            if (playerSpeed <= 0)
            {
                Debug.LogError($"{nameof(playerSpeed)} is not valid");
            }
        }
    }
}