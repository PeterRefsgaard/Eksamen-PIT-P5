using UnityEngine;

public class UIButtonSound : MonoBehaviour
{
    public AudioSource buttonClickSound; 
    public void PlayClickSound()
    {
        if (buttonClickSound != null)
        {
            buttonClickSound.Play();
        }
    }
}
