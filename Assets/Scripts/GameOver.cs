using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject Level;
    public GameObject GameOverUI;
    public GameObject ScoreUI;

    public void OnGameOver()
    {
        ScoreUI.SetActive(false);
        GameOverUI.SetActive(true);
        Level.SetActive(false);
    }
}
