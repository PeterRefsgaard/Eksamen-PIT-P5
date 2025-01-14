using UnityEngine;
using System.Collections;
using TMPro;

public class CalibrationNoticer : MonoBehaviour
{
    public GameObject leftController;
    public GameObject rightController;
    public GameObject leftCalibrationPoint;
    public GameObject rightCalibrationPoint;
    public float countdownDuration = 3f;

    [Header("UI Elements")]
    public TMP_Text countdownText;
    public GameObject infoText;
    public GameObject beginFlappingText;
    public GameObject uiCanvas;

    private bool leftInCircle = false;
    private bool rightInCircle = false;
    private float countdownTimer = 0f;
    private bool calibrationComplete = false;

    private void Start()
    {
        ResetCalibrationState(); 
    }
    private void Update()
    {
        if (calibrationComplete)
        {
            return;
        }
        leftInCircle = IsInsideCircle(leftController.transform.position, leftCalibrationPoint.transform.position, leftCalibrationPoint.transform.localScale.x / 2);
        rightInCircle = IsInsideCircle(rightController.transform.position, rightCalibrationPoint.transform.position, rightCalibrationPoint.transform.localScale.x / 2);
        if (leftInCircle && rightInCircle)
        {
            countdownTimer += Time.deltaTime;
            UpdateCountdownText(Mathf.Ceil(countdownDuration - countdownTimer).ToString());
            if (countdownTimer >= countdownDuration)
            {
                CompleteCalibration();
            }
        }
        else
        {
            countdownTimer = 0f;
            UpdateCountdownText("");
        }
    }

    private bool IsInsideCircle(Vector3 point, Vector3 circleCenter, float radius)
    {
        float distance = Vector3.Distance(new Vector3(point.x, 0, point.z), new Vector3(circleCenter.x, 0, circleCenter.z));
        return distance <= radius;
    }
    private void UpdateCountdownText(string text)
    {
        if (countdownText != null)
        {
            countdownText.text = text;
        }
    }

    private void CompleteCalibration()
    {
        calibrationComplete = true;

        if (leftCalibrationPoint != null)
            leftCalibrationPoint.SetActive(false);
        if (rightCalibrationPoint != null)
            rightCalibrationPoint.SetActive(false);
        if (infoText != null)
            infoText.SetActive(false);
        UpdateCountdownText("");
        if (beginFlappingText != null)
            beginFlappingText.SetActive(true);
        if (GameManagement.Instance != null)
        {
            GameManagement.Instance.StartGame();
        }
        StartCoroutine(DeactivateUICanvasAfterDelay(2f));    
    }
    private IEnumerator DeactivateUICanvasAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (uiCanvas != null)
        {
            uiCanvas.SetActive(false);
        }
    }
    public void ResetCalibrationState()
    {
        Time.timeScale = 1;
        calibrationComplete = false;
        countdownTimer = 0f;
        if (leftCalibrationPoint != null)
        {
            leftCalibrationPoint.SetActive(false);
        }
        if (rightCalibrationPoint != null)
        {
            rightCalibrationPoint.SetActive(false);
        }
        if (infoText != null)
        {
            infoText.SetActive(true);
        }
        if (beginFlappingText != null)
        {
            beginFlappingText.SetActive(false);
        }
        if (countdownText != null)
        {
            countdownText.text = "";
        }
        if (uiCanvas != null)
        {
            uiCanvas.SetActive(true);
        }
    }
    public void FullReset()
    {
        ResetCalibrationState();
    }
    public void ForceRestartCalibration()
    {
        calibrationComplete = false;
        countdownTimer = 0f;
        if (leftCalibrationPoint != null)
        {
            leftCalibrationPoint.SetActive(true);
        }
        if (rightCalibrationPoint != null)
        {
            rightCalibrationPoint.SetActive(true);
        }
        if (infoText != null)
        {
            infoText.SetActive(true); 
        }
        if (beginFlappingText != null)
        {
            beginFlappingText.SetActive(false); 
        }
        if (countdownText != null)
        {
            countdownText.text = "";
        }
    }
    public void ClearBeginFlappingText()
    {
        if (beginFlappingText != null)
        {
            beginFlappingText.SetActive(false);
        }
    }
}
