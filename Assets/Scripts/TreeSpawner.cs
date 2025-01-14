using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LateralPrefabSpawner : MonoBehaviour
{
    [Header("Prefab Options")]
    public GameObject[] prefabOptions;  // Array of different prefabs to spawn

    [Header("Spawn Parameters")]
    public Transform player;            // The player transform
    public float spawnDistance = 10f;   // Distance from the player to spawn the prefabs
    public float spawnInterval = 2f;    // Time interval between each spawn
    public float groundHeight = 0f;     // Fixed height for spawning (representing the ground level)
    public float minXOffset = 2f;      // Minimum X offset from the player's position
    public float maxXOffset = 5f;      // Maximum X offset from the player's position

    private Coroutine spawnCoroutine;  // Reference to the spawn coroutine

    private void Start()
    {
        // Start the spawning coroutine
        if (prefabOptions.Length > 0)
        {
            spawnCoroutine = StartCoroutine(SpawnPrefabs());
        }
        else
        {
         //   Debug.LogError("No prefabs assigned!");
        }
    }

    private IEnumerator SpawnPrefabs()
    {
        while (true)
        {
            // Check if the game is started
            if (GameManagement.Instance != null && GameManagement.Instance.IsGameStarted())
            {
                SpawnPrefab(); // Spawn a prefab
            }

            yield return new WaitForSeconds(spawnInterval); // Wait for the interval
        }
    }

    private void SpawnPrefab()
    {
        // Ensure there are prefabs to spawn
        if (prefabOptions.Length == 0)
        {
          //  Debug.LogError("No prefabs assigned!");
            return;
        }

        // Choose a random prefab from the available ones
        int randomIndex = Random.Range(0, prefabOptions.Length);
        GameObject selectedPrefab = prefabOptions[randomIndex];

        // Calculate spawn position in front of the player
        Vector3 spawnPosition = player.position + player.forward * spawnDistance;

        // Apply lateral variation (left/right)
        float xOffset = Random.Range(minXOffset, maxXOffset);
        // Ensure the spawn position does not directly align with the player
        if (Random.Range(0f, 1f) > 0.5f)
        {
            xOffset = -xOffset;  // Randomly decide to apply positive or negative offset
        }

        spawnPosition.x += xOffset;

        // Set the spawn height to a fixed value (ground level)
        spawnPosition.y = groundHeight;

        // Instantiate the selected prefab at the calculated position
        Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);

        // Debug: Show spawn position for debugging purposes
       // Debug.Log($"Spawned prefab at position: {spawnPosition}");
    }

    private void OnDestroy()
    {
        // Stop the coroutine when the spawner is destroyed
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
        }
    }
}
