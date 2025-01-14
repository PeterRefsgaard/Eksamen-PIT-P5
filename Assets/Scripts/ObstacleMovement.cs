using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speed = 5f;             
    private bool hasPassedPlayer = false;
    private float playerZPosition;       
    private PlayerScore playerScore;    
    private void Start()
    {
        playerScore = FindObjectOfType<PlayerScore>();
    }

    private void Update()
    {
        if (GameManagement.Instance != null && !GameManagement.Instance.IsGameStarted())
        {
            return; 
        }
        transform.position += Vector3.back * speed * Time.deltaTime;
        if (!hasPassedPlayer && transform.position.z < playerZPosition)
        {
            hasPassedPlayer = true;
            if (playerScore != null)
            {
                playerScore.AddScore(1); 
            }
        }
        if (transform.position.z < -10f)
        {
            Destroy(gameObject);
        }
    }
    public void SetPlayerZPosition(float playerZ)
    {
        playerZPosition = playerZ;
    }
}
