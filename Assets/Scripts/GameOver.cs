using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject Level;
    public GameObject GameOverUI;
    public GameObject Player;
    public GameObject ScoreUI;
    public void OnGameOver()
    {
        Player.SetActive(false);
        GameOverUI.SetActive(true);
        Level.SetActive(false);
        ScoreUI.SetActive(false);
    }
}
