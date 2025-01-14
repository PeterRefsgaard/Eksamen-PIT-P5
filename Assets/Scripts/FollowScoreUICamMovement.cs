using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScoreUI : MonoBehaviour
{
    public Transform cameraTransform;  
    public Vector3 offset = new Vector3(0, 1, 2);

    private void Update()
    {
        transform.position = cameraTransform.position + cameraTransform.forward * offset.z + cameraTransform.up * offset.y + cameraTransform.right * offset.x;
    }
}

