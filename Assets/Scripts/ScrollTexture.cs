using UnityEngine;

public class ScrollTexture : MonoBehaviour
{
    public float scrollSpeedZ = -0.01f;
    private Renderer rend; 
    private Vector2 currentOffset; 

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        if (rend != null)
        {
            currentOffset.y += scrollSpeedZ * Time.deltaTime;
            rend.material.SetTextureOffset("_BaseMap", currentOffset);
        }
    }
}
