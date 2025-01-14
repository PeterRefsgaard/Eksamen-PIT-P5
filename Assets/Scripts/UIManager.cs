using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class UIManager : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject initialUIElements;
    public GameObject secondaryUIElements;
    public GameObject calibrationUIElements;
    public GameObject calibrationUIInfoElements;
    public GameObject lastUIElements;

    [Header("Calibration Points")]
    public GameObject leftCalibrationPoint;
    public GameObject rightCalibrationPoint;

    public CalibrationNoticer calibrationNoticer;

    private void Start()
    {
        ResetCalibrationPoints();
    }
    public void OnStartButtonPressed()
    {
        if (initialUIElements != null)
        {
            initialUIElements.SetActive(false);
        }

        if (secondaryUIElements != null)
        {
            secondaryUIElements.SetActive(true);
        }
    }
    public void OnBackButtonPressed()
    {
        if (initialUIElements != null)
        {
            initialUIElements.SetActive(true);
        }
        if (secondaryUIElements != null)
        {
            secondaryUIElements.SetActive(false);
        }
        if (calibrationUIElements != null)
        {
            calibrationUIElements.SetActive(false);
        }
        if (lastUIElements != null)
        {
            lastUIElements.SetActive(false);
        }
        ResetCalibrationPoints();
    }
    public void OnSelectCalibrationButtonPressed()
    {
        if (secondaryUIElements != null)
        {
            secondaryUIElements.SetActive(false);
        }
        if (calibrationUIElements != null)
        {
            calibrationUIElements.SetActive(true);
        }
    }
    public void OnMode1Pressed()
    {
        if (calibrationNoticer != null)
        {
            calibrationNoticer.ForceRestartCalibration(); 
        }
        if (leftCalibrationPoint != null)
        {
            leftCalibrationPoint.SetActive(true);
        }
        if (rightCalibrationPoint != null)
        {
            rightCalibrationPoint.SetActive(true);
        }
        if (calibrationUIElements != null)
        {
            calibrationUIElements.SetActive(false);
        }
        if (calibrationUIInfoElements != null)
        {
            calibrationUIInfoElements.SetActive(true);
        }
    }
    public void OnBackButtonPressedInGameOver()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        StartCoroutine(ResetAfterSceneReload());
    }
    private IEnumerator ResetAfterSceneReload()
    {
        yield return null;
        if (calibrationNoticer != null)
        {
            calibrationNoticer.ResetCalibrationState();
        }
        Time.timeScale = 1;
    }
    public void DisableAllUIExceptLast()
    {
        if (initialUIElements != null)
            initialUIElements.SetActive(false);
        if (secondaryUIElements != null)
            secondaryUIElements.SetActive(false);
        if (calibrationUIElements != null)
            calibrationUIElements.SetActive(false);
        if (calibrationUIInfoElements != null)
            calibrationUIInfoElements.SetActive(false);
        if (lastUIElements != null)
            lastUIElements.SetActive(false); 
    }
    private void ResetCalibrationPoints()
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
