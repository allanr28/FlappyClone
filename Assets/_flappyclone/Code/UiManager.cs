using TMPro;
using UnityEngine;

namespace AllanReford._flappyclone.Code
{
    public class UiManager : MonoBehaviour
    {
        public TextMeshProUGUI scoreText;
        public TextMeshProUGUI hiscoreText;
        public TextMeshProUGUI countDownText;

        public Transform pauseMenu;
        
        public TextMeshProUGUI gameOverText;

        public void UpdateScoreText(int val)
        {
            scoreText.text = "Score: "  + val.ToString();
        }

        public void UpdateHiScoreText(int val)
        {
            hiscoreText.text = "HiScore: " + val.ToString();
        }
        public void UpdateCountDownText(float val)
        {
            countDownText.text = val.ToString();
        }
        
        public void ShowCountDownText()
        {
            countDownText.gameObject.SetActive(true);
        }
        
        public void HideCountDownText()
        {
            countDownText.gameObject.SetActive(false);
        }
        
        public void ShowGameOverText()
        {
            gameOverText.gameObject.SetActive(true);
        }
        
        public void HideGameOverText()
        {
            gameOverText.gameObject.SetActive(false);
        }

        public void TogglePauseMenu(bool toggle)
        {
            pauseMenu.gameObject.SetActive(toggle);
        }
        
    }
}
