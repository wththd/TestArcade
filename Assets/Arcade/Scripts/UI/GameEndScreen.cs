using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Arcade.Scripts.UI
{
    public class GameEndScreen : MonoBehaviour
    {
        private const string WinText = "Победа";
        private const string LooseText = "Поражение";

        [SerializeField] private TextMeshProUGUI resultText;

        public void SetResult(bool win)
        {
            resultText.text = win ? WinText : LooseText;
        }

        public void OnRestartClick()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}