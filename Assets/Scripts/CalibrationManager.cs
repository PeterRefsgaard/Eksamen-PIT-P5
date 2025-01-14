using UnityEngine;

public class CalibrationManager : MonoBehaviour
{
    public GameObject leftCalibrationPoint; 
    public GameObject rightCalibrationPoint; 
    public void ActivateCalibrationPoints()
    {
        if (leftCalibrationPoint != null)
        {
            leftCalibrationPoint.SetActive(true); 
        }
        if (rightCalibrationPoint != null)
        {
            rightCalibrationPoint.SetActive(true); 
        }
    }
    public void DeactivateCalibrationPoints()
    {
        if (leftCalibrationPoint != null)
        {
            leftCalibrationPoint.SetActive(false);
        }
        if (rightCalibrationPoint != null)
        {
            rightCalibrationPoint.SetActive(false);
        }
    }
}
