using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public static TimerController instance;

    public Text timeCounter; // makes the time public so that it can be used from another script to actually display the speedrun timer

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

    private void Start() // will be called on scene creation.
    {
        timeCounter.text = "Time: 00:00.00";
        timerGoing = false;
        BeginTimer();
    }
    
    public void BeginTimer() // will also be called on scene cration
    {
        timerGoing = true;
        elapsedTime = 0f;

        StartCoroutine(UpdateTimer());
    }

    public void EndTimer() //will be called when finish reached
    {
        timerGoing = false;
    }

    private IEnumerator UpdateTimer() // simply adds the time between frames to a timer after each frame untill timergoing is toggled off.
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
