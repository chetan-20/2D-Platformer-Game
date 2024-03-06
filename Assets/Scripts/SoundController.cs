using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    private static SoundController instance;
    public static SoundController Instance { get { return instance; } }

    public AudioSource SoundEffect;
    public AudioSource Music;

    public SoundType[] Sounds; 
    void Awake()
    {
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
    
    public void PlaySound(Sounds sound)
    {
        AudioClip clip = GetSoundClip(sound);
        if (clip != null)
        {
            SoundEffect.PlayOneShot(clip);
        }
        else
        {
            Debug.Log("Audio Not Assigned");
        }
    }
    private AudioClip GetSoundClip(Sounds sound)
    {
        
        SoundType item = Array.Find(Sounds, i => i.soundtype == sound);
        if (item != null)
        {
            return item.soundclip;
        }
        else
        {
            return null;
        }
    }
} 
     [Serializable]
    public class SoundType
    {
        public Sounds soundtype;
        public AudioClip soundclip;
    }

public enum Sounds
    {
        BGMusic,
        ButtonClick,
        DeathSound,
        KeyPickUpSound,
        JumpSound,
        CrouchSound,
        HealthLostSound,
        LevelCompleteSound,
        LevelFallOffSound,
        LevelLockedSound
    }