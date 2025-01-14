using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    [Header("Prefab Options")]
    public GameObject[] prefabOptions; 
    [Header("Spawn Parameters")]
    public Transform player;            
    public float spawnDistance = 10f;  
    public float spawnInterval = 2f;   
    public float groundHeight = 0f;    
    public float minXOffset = 2f;      
    public float maxXOffset = 5f;      

    private Coroutine spawnCoroutine; 

    private void Start()
    {
        if (prefabOptions.Length > 0)
        {
            spawnCoroutine = StartCoroutine(SpawnPrefabs());
        }
    }
    private IEnumerator SpawnPrefabs()
    {
        while (true)
        {
            if (GameManagement.Instance != null && GameManagement.Instance.IsGameStarted())
            {
                SpawnPrefab(); 
            }
            yield return new WaitForSeconds(spawnInterval); 
        }
    }
    private void SpawnPrefab()
    {
        if (prefabOptions.Length == 0)
        {
            return;
        }
        int randomIndex = Random.Range(0, prefabOptions.Length);
        GameObject selectedPrefab = prefabOptions[randomIndex];
        Vector3 spawnPosition = player.position + player.forward * spawnDistance;
        float xOffset = Random.Range(minXOffset, maxXOffset);
        if (Random.Range(0f, 1f) > 0.5f)
        {
            xOffset = -xOffset; 
        }
        spawnPosition.x += xOffset;
        spawnPosition.y = groundHeight;
        Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
    }

    private void OnDestroy()
    {
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
        }
    }
}
