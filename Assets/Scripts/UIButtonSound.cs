using UnityEngine;

public class UIButtonSound : MonoBehaviour
{
    public AudioSource buttonClickSound; // Reference til AudioSource

    public void PlayClickSound()
    {
        if (buttonClickSound != null)
        {
            buttonClickSound.Play(); // Afspil lyden
        }
        else
        {
            Debug.LogWarning("No AudioSource assigned to the button!");
        }
    }
}
