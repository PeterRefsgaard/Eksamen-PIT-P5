using UnityEngine;
using TMPro;

public class HighscoreUpdateDisplay : MonoBehaviour
{
    public TextMeshProUGUI highscoreText; 
    private HighscoreManager highscoreManager; 

    private void Start()
    {
        highscoreManager = FindObjectOfType<HighscoreManager>(); 
        if (highscoreManager != null)
        {
            highscoreManager.LoadHighscore(); 
            UpdateHighscoreText(); 
        }
    }
    private void UpdateHighscoreText()
    {
        if (highscoreManager != null && highscoreText != null)
        {
            highscoreText.text = "Highscore: " + highscoreManager.highscore.ToString();
        }
    }
}


