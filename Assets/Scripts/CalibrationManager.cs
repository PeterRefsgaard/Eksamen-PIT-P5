using UnityEngine;

public class CalibrationManager : MonoBehaviour
{
    public GameObject leftCalibrationPoint;  // Reference til venstre cirkel
    public GameObject rightCalibrationPoint; // Reference til h?jre cirkel

    // Metode til at aktivere kalibreringspunkterne
    public void ActivateCalibrationPoints()
    {
        if (leftCalibrationPoint != null)
        {
            leftCalibrationPoint.SetActive(true); // Aktiver venstre cirkel
        }
        if (rightCalibrationPoint != null)
        {
            rightCalibrationPoint.SetActive(true); // Aktiver h?jre cirkel
        }

        Debug.Log("Calibration points activated!");
    }
    public void DeactivateCalibrationPoints()
    {
        if (leftCalibrationPoint != null)
        {
            leftCalibrationPoint.SetActive(false); // Deaktiver venstre cirkel
        }
        if (rightCalibrationPoint != null)
        {
            rightCalibrationPoint.SetActive(false); // Deaktiver h?jre cirkel
        }

        Debug.Log("Calibration points deactivated!");
    }
}
