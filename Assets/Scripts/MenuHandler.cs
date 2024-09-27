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
    }

    public void onBackButtonPress()
    {
        LevelScreen.SetActive(false);
        MenuScreen.SetActive(true);
    }

}
