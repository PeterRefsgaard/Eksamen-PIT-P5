using UnityEngine;
using UnityEngine.InputSystem;

public class FlightControl : MonoBehaviour
{
    public InputActionProperty leftHandPositionAction;
    public InputActionProperty rightHandPositionAction;
    public Transform leftCalibrationPoint;
    public Transform rightCalibrationPoint;
    public Rigidbody sphere;

    public float upwardForce = 8f;
    public float downwardForce = -8f;
    public float gentleDescendForce = -2f;
    public float movementSensitivity = 0.1f;

    private Vector3 initialLeftHandPosition;
    private Vector3 initialRightHandPosition;
    private bool initialized = false;

    private void Start()
    {
        if (sphere != null)
        {
            sphere.isKinematic = true;
            sphere.useGravity = false;
        }
    }

    private void FixedUpdate()
    {
        if (GameManagement.Instance == null || !GameManagement.Instance.IsGameStarted())
        {
            if (sphere != null)
            {
                sphere.isKinematic = true;
                sphere.useGravity = false;
            }
            return;
        }

        if (sphere.isKinematic)
        {
            sphere.isKinematic = false;
            sphere.useGravity = false;
        }

        Vector3 leftHandPosition = leftHandPositionAction.action.ReadValue<Vector3>();
        Vector3 rightHandPosition = rightHandPositionAction.action.ReadValue<Vector3>();

        if (!initialized)
        {
            if (leftHandPosition != Vector3.zero && rightHandPosition != Vector3.zero)
            {
                initialLeftHandPosition = leftHandPosition;
                initialRightHandPosition = rightHandPosition;
                initialized = true;
                Debug.Log("Initial hand positions set!");
            }
            return;
        }

        float leftDeltaY = leftHandPosition.y - initialLeftHandPosition.y;
        float rightDeltaY = rightHandPosition.y - initialRightHandPosition.y;
        float averageDeltaY = (leftDeltaY + rightDeltaY) / 2f;

        if (averageDeltaY < -movementSensitivity)
        {
            ApplyForce(Vector3.up * upwardForce);
        }
        else if (averageDeltaY > movementSensitivity)
        {
            ApplyForce(Vector3.up * downwardForce);
        }
        else
        {
            ApplyForce(Vector3.up * gentleDescendForce);
        }
    }

    private void ApplyForce(Vector3 force)
    {
        if (sphere != null)
        {
            sphere.AddForce(force, ForceMode.Acceleration);
        }
    }
}
