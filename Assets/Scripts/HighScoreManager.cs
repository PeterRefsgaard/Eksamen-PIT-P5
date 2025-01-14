using TMPro;
using UnityEngine;

public class HighscoreManager : MonoBehaviour
{
    public int highscore = 0;

    private const string HighscoreKey = "Highscore"; 
    public void LoadHighscore()
    {
        highscore = PlayerPrefs.GetInt(HighscoreKey, 0); 
    }
    public void SaveHighscore(int score)
    {
        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt(HighscoreKey, highscore);
            PlayerPrefs.Save();
        }
    }
    public void DisplayHighscore(TextMeshProUGUI highscoreText)
    {
        if (highscoreText != null)
        {
            highscoreText.text = "Highscore: " + highscore.ToString();
        }
    }
}



