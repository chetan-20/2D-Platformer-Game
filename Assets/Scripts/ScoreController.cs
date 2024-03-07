using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreController : MonoBehaviour
{
    private TextMeshProUGUI Text_Score;
    private int score = 0;
    private void Awake()
    {
        Text_Score = GetComponent<TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    void Start()
    {
        RefreshUI();
    }

    private void RefreshUI()
    {
        Text_Score.text = "Score : " + score;
    }

    public void UpdateScore(int increment)
    {
        score += increment;
        RefreshUI();
    }
}
