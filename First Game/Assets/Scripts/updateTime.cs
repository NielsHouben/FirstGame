using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updateTime : MonoBehaviour
{
    // public TimeController t;
    Text txt;
    void Start()
    {
        txt = gameObject.GetComponent<Text>();
        // TimerController gm = GameObject.Find("Game Master");
        // TimerController gmScript = gm.GetComponent<TimeController>();
        // playerScript.Health -= 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // string timePlayingStr = "Time: " + t.timePlaying.ToString("mm':'ss'.'ff");
        // txt.text = timePlayingStr;
        // Debug.Log(GameObject.Find("Game Master").GetComponent<TimerController>().timePlayingString);
        txt.text = GameObject.Find("Game Master").GetComponent<TimerController>().timePlayingString;
    }
}
