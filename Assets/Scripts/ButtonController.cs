using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public GameObject LevelScreen;
    public GameObject MenuScreen;
    
    public void LoadNext()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

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
