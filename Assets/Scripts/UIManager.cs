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
        // S?rg for, at alt starter korrekt
        ResetCalibrationPoints();
    }

    // Metode til at aktivere Secondary UI og deaktivere Initial UI
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

    // Metode til at g? tilbage fra andre UI-sektioner til Initial UI
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

    // Metode til at v?lge kalibreringsmuligheder
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

    // Metode til at aktivere Mode 1 kalibreringslogik
    public void OnMode1Pressed()
    {
        if (calibrationNoticer != null)
        {
            calibrationNoticer.ForceRestartCalibration(); // Genstart kalibreringen
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

        Debug.Log("Mode1 pressed: Calibration restarted.");
    }

    // Metode til "Back" knappen - Nulstil til hovedmenuen
    public void OnBackButtonPressedInGameOver()
    {
        Time.timeScale = 1; // S?rg for, at tiden k?rer normalt
        Debug.Log("Time.timeScale set to 1 before reloading the scene.");

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        StartCoroutine(ResetAfterSceneReload());
    }


    private IEnumerator ResetAfterSceneReload()
    {
        yield return null; // Vent p?, at scenen er genindl?st

        if (calibrationNoticer != null)
        {
            calibrationNoticer.ResetCalibrationState();
            Debug.Log("CalibrationNoticer reset after scene reload.");
        }

        Time.timeScale = 1; // S?rg for, at spillet ikke er paused
    }


    // Metode til "Retry" knappen - Genstart med Mode1
    // Metode til "Retry" knappen - Genstart med Mode1
    public void OnRetryButtonPressed()
    {
        StartCoroutine(RetryWithMode1());
    }

    private IEnumerator RetryWithMode1()
    {
        // Genindl?s scenen
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        yield return null; // Vent til scenen er fuldt genindl?st

        // S?rg for, at tiden ikke er pauset
        if (GameManagement.Instance != null)
        {
            GameManagement.Instance.StartGame();
            Time.timeScale = 1;
        }

        // Vent et frame for at sikre alle objekter er initialiseret
        yield return null;

        // Aktiver Mode1-tilstand automatisk
        if (calibrationNoticer != null)
        {
            calibrationNoticer.ResetCalibrationState(); // Nulstil kalibreringstilstanden
            Debug.Log("CalibrationNoticer reset after Retry.");
        }

        OnMode1Pressed(); // Simuler "Mode1"-knappen trykket
        Debug.Log("Retry button: Scene reloaded and Mode1 activated.");
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
            lastUIElements.SetActive(false); // Ensure it's not accidentally activated before the collision logic

        Debug.Log("All UI elements deactivated except Last UI.");
    }


    // Nulstil kalibreringspunkterne til deres oprindelige tilstand
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
        Debug.Log("Calibration points have been reset.");
    }
}
