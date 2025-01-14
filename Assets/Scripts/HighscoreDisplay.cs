using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI highscoreText; // Assign this in the Inspector
    private HighscoreManager highscoreManager; // Reference to the HighscoreManager

    private void Start()
    {
        highscoreManager = FindObjectOfType<HighscoreManager>(); // Find the HighscoreManager in the scene

        if (highscoreManager != null)
        {
            highscoreManager.LoadHighscore(); // Load the highscore
            UpdateHighscoreText(); // Update the UI
        }
    }

    private void UpdateHighscoreText()
    {
        if (highscoreManager != null && highscoreText != null)
        {
            highscoreText.text = "Highscore: " + highscoreManager.highscore.ToString(); // Display the highscore
        }
    }
}


