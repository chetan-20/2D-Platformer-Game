using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelWonController : MonoBehaviour
{
    public GameObject Level;
    public GameObject LevelWon;
    public GameObject Player;
    public GameObject ScoreUI;
  
    
        
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            SoundController.Instance.StopFootSound();
            Player.SetActive(false);
            Level.SetActive(false);
            LevelWon.SetActive(true);
           ScoreUI.SetActive(false);
            LevelManager.Instance.MarkCurrentLevelComplete();
            SoundController.Instance.PlaySound(Sounds.LevelCompleteSound);
        }
    }
}
