using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updateScore : MonoBehaviour
{
    // Start is called before the first frame update
    Text txt;
    void Start()
    {
        txt = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Player.score);
        // txt.text = "5";
        txt.text = "" + Player.score;
    }
}
