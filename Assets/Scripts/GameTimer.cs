using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    float gameTimer = 0f;
    private TimeSpan timePlaying;
    public GameObject Player;

    // Update is called once per frame
    void Update()
    {
        gameTimer += Time.deltaTime;
        timePlaying = TimeSpan.FromSeconds(gameTimer);

        string gameTimerStr = "Time:" + timePlaying.ToString("mm':'ss");
        timerText.text = gameTimerStr;

    }
}
