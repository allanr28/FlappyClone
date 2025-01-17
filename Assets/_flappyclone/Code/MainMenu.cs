using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AllanReford._flappyclone.Code
{
    public class MainMenu : MonoBehaviour
    {

        public TextMeshProUGUI highscoreText;

        private void Start()
        {
            int highscore = PlayerPrefs.GetInt("HighScore");
            
            if(highscore > 0)
                highscoreText.text = "Highscore: " + highscore.ToString();
            else
            {
                highscoreText.text = "";
            }
        }

        public void StartGame()
        {
            SceneManager.LoadScene(1);
        }
    }
}
