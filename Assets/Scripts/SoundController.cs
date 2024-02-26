using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource clicksound;

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
    }
}
