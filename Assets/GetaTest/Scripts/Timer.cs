using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    public float TimerClock;
    public float startTime;
    public Text clockText;
    public bool EndGame;
    // Start is called before the first frame update
    void Start()
    {
        TimerClock = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        timerUpdate();
     
    }
    /// <summary>
    /// Display the timer on screen
    /// </summary>
    void timerUpdate()
    {
        if (TimerClock >= 0)
        {
            TimerClock -= Time.deltaTime;
            clockText.text = Math.Ceiling(TimerClock).ToString();
        }
        else
        {
            EndGame = true;
        }
    }
    /// <summary>
    /// Add 10 seconds to the timer
    /// </summary>
     public void addtime()
    {

        TimerClock += 10;
    }

    public float getTime()
    {
        return TimerClock;
    }

    public bool getEndGame ()
    {
        return EndGame;
    }
 
}
