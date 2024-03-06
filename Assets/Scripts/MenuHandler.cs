using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    public GameObject LevelScreen;
    public GameObject MenuScreen;

    public void onLevelButtonPress()
    {
        LevelScreen.SetActive(true);
        MenuScreen.SetActive(false);
        SoundController.Instance.PlaySound(Sounds.ButtonClick);
    }

    public void onBackButtonPress()
    {
        SoundController.Instance.PlaySound(Sounds.ButtonClick);
        LevelScreen.SetActive(false);
        MenuScreen.SetActive(true);
    }

}
