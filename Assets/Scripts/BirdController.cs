using UnityEngine;
using UnityEngine.InputSystem;

public class BirdController : MonoBehaviour
{
    [Header("Input Actions")]
    public InputActionProperty leftHandPositionAction;  // Venstre h?nd position
    public InputActionProperty rightHandPositionAction; // H?jre h?nd position

    [Header("Movement Settings")]
    public float movementSpeed = 2.0f; // Hvor hurtigt fuglen bev?ger sig
    public float sensitivity = 0.1f;   // F?lsomhed for h?ndbev?gelse

    private Vector3 initialLeftHandPosition;
    private Vector3 initialRightHandPosition;
    private bool initialized = false;

    void Update()
    {
        // Hent h?ndpositioner
        Vector3 leftHandPosition = leftHandPositionAction.action.ReadValue<Vector3>();
        Vector3 rightHandPosition = rightHandPositionAction.action.ReadValue<Vector3>();

        // Initialiser startpositioner
        if (!initialized)
        {
            if (leftHandPosition != Vector3.zero && rightHandPosition != Vector3.zero)
            {
                initialLeftHandPosition = leftHandPosition;
                initialRightHandPosition = rightHandPosition;
                initialized = true; // Kun initialiser ?n gang
                Debug.Log("Initial hand positions set!");
            }
            return; // Vent, indtil h?nderne er initialiseret
        }

        // Beregn ?ndring i h?ndpositioner
        float leftHandDeltaY = leftHandPosition.y - initialLeftHandPosition.y;
        float rightHandDeltaY = rightHandPosition.y - initialRightHandPosition.y;

        // Gennemsnit af h?ndbev?gelser
        float averageDeltaY = (leftHandDeltaY + rightHandDeltaY) / 2.0f;

        // Bev?g sf?ren op/ned
        if (Mathf.Abs(averageDeltaY) > sensitivity)
        {
            transform.position += new Vector3(0, averageDeltaY * movementSpeed * Time.deltaTime, 0);
        }
    }

}