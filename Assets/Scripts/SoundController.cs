using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    private static SoundController instance;
    public static SoundController Instance { get { return instance; } }

    public AudioSource SoundEffect;
    public AudioSource SoundMusic;
    public AudioSource SoundFootStep;
    public bool IsMute=false;
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
    private void Start()
    {
        PlayMusic(global::Sounds.BGMusic);
    }
    public void PlayMusic(Sounds sound)
    {
        if (IsMute)
        {
            return;
        }
        AudioClip clip = GetSoundClip(sound);
        if (clip != null)
        {
            SoundMusic.clip = clip; 
            SoundMusic.Play();
        }
        else
        {
            Debug.Log("Audio Not Assigned");
        }
    }

    public void PlayFootStep(int lives)
    {
        if (IsMute)
        {
            return;
        }
        else
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {


                SoundFootStep.enabled = true;
                SoundFootStep.Play();

            }
            else if (lives <= 0)
            {
                SoundFootStep.enabled = false;

            }
            else
            {
                SoundFootStep.enabled = false;
            }
        }
    }

    public void Mute(bool status)
    {
        IsMute = status;
    }
    public void PlaySound(Sounds sound)
    {
        if (IsMute)
        {
            return;
        }
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
        LevelLockedSound,
        
    }