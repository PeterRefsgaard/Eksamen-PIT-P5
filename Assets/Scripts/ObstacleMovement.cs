using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Make sure you have TextMeshPro namespace if you're using TextMeshPro for score

public class ObstacleMovement : MonoBehaviour
{
    public float speed = 5f;             // The speed at which the obstacle moves
    private bool hasPassedPlayer = false; // Flag to track if the obstacle has passed the player
    private float playerZPosition;       // Z position of the player when the obstacle spawns
    private PlayerScore playerScore;     // Reference to the player's score script

    private void Start()
    {
        // Get the PlayerScore component from the scene
        playerScore = FindObjectOfType<PlayerScore>();
    }

    private void Update()
    {
        // Check if the game is started
        if (GameManagement.Instance != null && !GameManagement.Instance.IsGameStarted())
        {
            return; // Do not move if the game hasn't started
        }

        // Move the obstacle towards the player (along negative Z-axis)
        transform.position += Vector3.back * speed * Time.deltaTime;

        // Check if the obstacle has passed the player
        if (!hasPassedPlayer && transform.position.z < playerZPosition)
        {
            hasPassedPlayer = true; // Mark as passed
            if (playerScore != null)
            {
                playerScore.AddScore(1); // Add a point to the player's score
            }
        }

        // Optionally destroy the obstacle once it's out of the screen
        if (transform.position.z < -10f)
        {
            Destroy(gameObject);
        }
    }

    // Set the initial player Z position when the obstacle spawns
    public void SetPlayerZPosition(float playerZ)
    {
        playerZPosition = playerZ;
    }
}
