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
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject); 
    }
    public void StartGame()
    {
        Time.timeScale = 1; 
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
    }

    public bool IsGameStarted()
    {
        return isGameStarted;
    }

    public void ResetGame()
    {
        isGameStarted = false;
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
    }
    public void ResetSingleton()
    {
        Instance = null;
        Destroy(gameObject);
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
