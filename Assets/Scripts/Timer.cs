using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float time = 0;
    private bool timerIsRunning = true;
    public TextMeshProUGUI timeText;
    void Update()
    {   
        if (Globals.score == "3/3")
        {
            timerIsRunning = false;
        }

        if (timerIsRunning)
        {
            time += Time.deltaTime;
            DisplayTime(time);
        }

    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
