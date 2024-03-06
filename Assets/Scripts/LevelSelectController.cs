using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



 [RequireComponent(typeof(Button))]
public class LevelSelectController : MonoBehaviour
{
  


    [SerializeField] string LevelName;
    private Button button;
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        ;
        LevelManager.LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(LevelName);
        switch (levelStatus)
        {
            case LevelManager.LevelStatus.Locked :
                Debug.Log("Level is Locked");
                SoundController.Instance.PlaySound(Sounds.LevelLockedSound);
                break;
            case LevelManager.LevelStatus.Unlocked:
                SceneManager.LoadScene(LevelName);
                SoundController.Instance.PlaySound(Sounds.ButtonClick);
                break;
            case LevelManager.LevelStatus.Completed:
                SceneManager.LoadScene(LevelName);
                SoundController.Instance.PlaySound(Sounds.ButtonClick);
                break;
        }
        
    }
}
