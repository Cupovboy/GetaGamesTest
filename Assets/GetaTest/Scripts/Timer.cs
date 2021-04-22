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

    void timerUpdate()
    {
        if (TimerClock >= 0)
        {
            TimerClock -= Time.deltaTime;
            clockText.text = Math.Ceiling(TimerClock).ToString();
        }
    }

     public void addtime()
    {

        TimerClock += 10;
    }

    public float getTime()
    {
        return TimerClock;
    }

 
}
