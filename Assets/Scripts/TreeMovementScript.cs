using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMovementScript : MonoBehaviour
{
    public float speed = 5f;              
    private float playerZPosition;       

    private void Update()
    {
        if (GameManagement.Instance != null && GameManagement.Instance.IsGameStarted())
        {
            transform.position += Vector3.back * speed * Time.deltaTime;
            if (transform.position.z < -10f)
            {
                Destroy(gameObject); 
            }
        }
    }
    public void SetPlayerZPosition(float playerZ)
    {
        playerZPosition = playerZ;
    }
}
