using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{

    /*public AudioSource clicksound;

    void Awake()
    {
        // Ensure only one instance of SoundController exists
        if (FindObjectsOfType<SoundController>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayClickSound()
    {
        clicksound.Play();
    }*/
    public static SoundController instance; // Static reference to the SoundController instance
    public AudioSource clicksound;

    void Awake()
    {
        // Ensure only one instance of SoundController exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Method to play the click sound
    public void PlayClickSound()
    {
        if (clicksound != null)
        {
            clicksound.Play();
        }
        else
        {
            Debug.LogWarning("Click sound not assigned to the SoundController.");
        }
    }
}
