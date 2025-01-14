using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;  
    public Transform player;              
    public float spawnDistance = 10f;     
    public float spawnInterval = 2f;      
    public float minHeight = -4.5f;       
    public float maxHeight = 10f;         

    private Coroutine spawnCoroutine;     
    private List<GameObject> spawnedObstacles = new List<GameObject>(); 

    private void Start()
    {
        spawnCoroutine = StartCoroutine(SpawnObstacles());
    }
    private IEnumerator SpawnObstacles()
    {
        while (true)
        {
            if (GameManagement.Instance != null && GameManagement.Instance.IsGameStarted())
            {
                SpawnObstacle(); 
                yield return new WaitForSeconds(spawnInterval); 
            }
            else
            {
                yield return null;
            }
        }
    }

    private void SpawnObstacle()
    {
        if (obstaclePrefabs.Length == 0)
        {
            return;
        }
        int randomIndex = Random.Range(0, obstaclePrefabs.Length);
        GameObject selectedPrefab = obstaclePrefabs[randomIndex];
        Vector3 spawnPosition = player.position + player.forward * spawnDistance;
        spawnPosition.y = Random.Range(minHeight, maxHeight);  
        GameObject obstacle = Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
        spawnedObstacles.Add(obstacle);
        ObstacleMovement obstacleMovement = obstacle.GetComponent<ObstacleMovement>();
        if (obstacleMovement != null)
        {
            obstacleMovement.SetPlayerZPosition(player.position.z); 
        }
    }
    public void DespawnAllObstacles()
    {
        foreach (GameObject obstacle in spawnedObstacles)
        {
            if (obstacle != null)
            {
                Destroy(obstacle);
            }
        }
        spawnedObstacles.Clear();
    }
    private void OnDestroy()
    {
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
        }
    }
}
