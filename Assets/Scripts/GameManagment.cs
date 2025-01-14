using UnityEngine;

public class GameManagement : MonoBehaviour
{
    public static GameManagement Instance { get; private set; }
    private bool isGameStarted = false;

    [Header("UI Elements")]
    public GameObject initialUIElements;
    public GameObject secondaryUIElements;
    public GameObject calibrationModeUI;
    public GameObject lastUIElements;
    public GameObject calibrationPoints;

    private void Awake()
    {
        // Hvis en anden instans eksisterer, destruer den for at sikre ren opstart
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // G?r dette objekt persistent
    }

    public void StartGame()
    {
        Time.timeScale = 1; // S?rg for, at spillet k?rer normalt
        isGameStarted = true;

        if (initialUIElements != null)
            initialUIElements.SetActive(false);

        if (secondaryUIElements != null)
            secondaryUIElements.SetActive(false);

        if (calibrationModeUI != null)
            calibrationModeUI.SetActive(false);

        if (lastUIElements != null)
            lastUIElements.SetActive(false);

        if (calibrationPoints != null)
            calibrationPoints.SetActive(false);

        Debug.Log("Game started successfully. Time.timeScale: " + Time.timeScale);
    }

    public bool IsGameStarted()
    {
        return isGameStarted;
    }

    public void ResetGame()
    {
        isGameStarted = false;

        // Genskab UI-tilstand
        if (initialUIElements != null)
            initialUIElements.SetActive(true);

        if (secondaryUIElements != null)
            secondaryUIElements.SetActive(false);

        if (calibrationModeUI != null)
            calibrationModeUI.SetActive(false);

        if (lastUIElements != null)
            lastUIElements.SetActive(false);

        if (calibrationPoints != null)
            calibrationPoints.SetActive(false);

        Debug.Log("Game state has been reset.");
    }

    // Nulstil singleton ved scenegenindl?sning
    public void ResetSingleton()
    {
        Instance = null;
        Destroy(gameObject); // S?rg for, at objektet slettes
        Debug.Log("GameManagement singleton nulstillet.");
    }

    public void EndGame()
    {
        isGameStarted = false;
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
