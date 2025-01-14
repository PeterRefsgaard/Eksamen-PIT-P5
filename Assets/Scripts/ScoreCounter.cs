using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;
    private HighscoreManager highscoreManager;
    private AudioSource audioSource;

    private void Start()
    {
        highscoreManager = FindObjectOfType<HighscoreManager>();
        audioSource = GetComponent<AudioSource>();
        UpdateScoreText();

        // Load the high score at the start
        if (highscoreManager != null)
        {
            highscoreManager.LoadHighscore();
        }
    }

    public void AddScore(int points)
    {
        score += points;
        PlayScoreSound();
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    private void PlayScoreSound()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    public void OnGameOver()
    {
        if (highscoreManager != null)
        {
            highscoreManager.SaveHighscore(score); // Save the highscore
            highscoreManager.DisplayHighscore(scoreText); // Optionally display the highscore
        }
    }
}
