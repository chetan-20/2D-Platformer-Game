using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour
{
    private bool ispaused = false;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject PauseMenuUI;
    [SerializeField] private GameObject ScoreUI;
    [SerializeField] private Button button;
    private void Start()
    {
        button.onClick.AddListener(Onclick);
    }

    private void Onclick()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ispaused = !ispaused;
            OnApplicationPause(ispaused);
        }
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            Time.timeScale = 0.0f;
            Player.SetActive(false);
            PauseMenuUI.SetActive(true);
            ScoreUI.SetActive(false);
        }
        else
        {
            Time.timeScale = 1.0f;
            Player.SetActive(true);
            PauseMenuUI.SetActive(false);
            ScoreUI.SetActive(true );
        }
    }
}
