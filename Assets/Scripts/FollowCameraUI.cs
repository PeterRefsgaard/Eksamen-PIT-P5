using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCameraUI : MonoBehaviour
{
    public Transform cameraTransform;  // Reference to the camera
    public Vector3 offset = new Vector3(0, 1, 2); // The offset (relative position) from the camera

    private void Update()
    {
        // Update the position of the canvas to always be in front of the camera with the given offset
        transform.position = cameraTransform.position + cameraTransform.forward * offset.z + cameraTransform.up * offset.y + cameraTransform.right * offset.x;
    }
}

