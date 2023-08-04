using TMPro;
using UnityEngine;

namespace Arcade.Scripts.UI
{
    public class GameplayScreen : MonoBehaviour
    {
        private const string HealthPattern = "Здоровье : {0}";
        [SerializeField] 
        private TextMeshProUGUI healthText;

        public void SetHealth(int health)
        {
            healthText.text = string.Format(HealthPattern, health);
        }
    }
}