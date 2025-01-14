using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameObject lastUIElements; // Reference til Last UI Elements
    public Canvas uiCanvas; // Reference til det canvas, hvor UI-elementerne befinder sig

    private bool isGameOver = false;

    private void OnCollisionEnter(Collision collision)
    {
        // Check om kollisionen er med en obstacle
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Collision detected with obstacle: " + collision.gameObject.name);

            if (!isGameOver)
            {
                isGameOver = true;
                HandleGameOver();
            }
        }
    }

    private void HandleGameOver()
    {
        Debug.Log("Game Over! Stopping the game.");

        // Stop spillet ved at s?tte isGameStarted til false
        if (GameManagement.Instance != null)
        {
            GameManagement.Instance.EndGame();
        }

        // Aktiv?r det sidste UI-element
        if (lastUIElements != null)
        {
            lastUIElements.SetActive(true);
        }

        // Aktiv?r canvas, hvis det ikke allerede er aktivt
        if (uiCanvas != null)
        {
            uiCanvas.gameObject.SetActive(true);
        }
    }
}