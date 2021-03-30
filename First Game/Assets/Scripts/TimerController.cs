using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public static TimerController instance;

    public Text timeCounter;

    public  TimeSpan timePlaying;

    public string timePlayingString;

    private bool timerGoing;

    public float elapsedTime;

    private void Awake()
    {
        //instance = this;
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(instance);
        } else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        timeCounter.text = "Time: 00:00.00";
        timerGoing = false;
        BeginTimer();
    }
    
    public void BeginTimer()
    {
        timerGoing = true;
        elapsedTime = 0f;

        StartCoroutine(UpdateTimer());
    }

    public void EndTimer()
    {
        timerGoing = false;
    }

    private IEnumerator UpdateTimer()
    {
        while (timerGoing)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            timePlayingString = "" + timePlaying.ToString("mm':'ss'.'ff");
            // timeCounter.text = timePlayingStr;
            // Debug.Log(timePlayingString);

            yield return null;
        }
    }
}
