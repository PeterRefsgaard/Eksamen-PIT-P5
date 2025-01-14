using System.Collections;
using UnityEngine;

public class PlayerCollisionTrigger : MonoBehaviour
{
    public PlayerScore playerScore; 
    public AudioSource gameOverSound;
    public float delayBeforeGameOverUI = 2f; 

    private bool isGameOver = false; 
    public UIManager uiManager; 
    public CalibrationNoticer calibrationNoticer; 
    public ObstacleSpawner obstacleSpawner; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle")) 
        {
            if (!isGameOver)
            {
                isGameOver = true; 
                if (playerScore != null)
                {
                    playerScore.OnGameOver();
                }
                StartCoroutine(GameOverSequence(other.gameObject)); 
            }
        }
    }
    private IEnumerator GameOverSequence(GameObject collidedObstacle)
    {
        if (gameOverSound != null)
        {
            gameOverSound.Play();
        }
        Time.timeScale = 0;
        if (collidedObstacle != null)
        {
            Destroy(collidedObstacle); 
        }
        yield return new WaitForSecondsRealtime(2f);
        if (obstacleSpawner != null)
        {
            obstacleSpawner.DespawnAllObstacles();
        }
        if (calibrationNoticer != null && calibrationNoticer.uiCanvas != null)
        {
            calibrationNoticer.uiCanvas.SetActive(true);
        }
        if (uiManager != null)
        {
            uiManager.DisableAllUIExceptLast(); 
        }
        yield return new WaitForSecondsRealtime(delayBeforeGameOverUI);
        if (uiManager != null && uiManager.lastUIElements != null)
        {
            uiManager.lastUIElements.SetActive(true);
        }
    }
}
