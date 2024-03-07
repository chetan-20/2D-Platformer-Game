using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    
    
    public void LoadNext()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        SoundController.Instance.PlaySound(Sounds.ButtonClick);
    }

    public void QuitGame()
    {
        Application.Quit();
        SoundController.Instance.PlaySound(Sounds.ButtonClick);
    }

   

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SoundController.Instance.PlaySound(Sounds.ButtonClick);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
        SoundController.Instance.PlaySound(Sounds.ButtonClick);
    }
}
