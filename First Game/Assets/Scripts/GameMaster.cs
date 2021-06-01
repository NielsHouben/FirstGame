using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameMaster : MonoBehaviour
{
    // Start is called before the first frame update
    private static GameMaster instance;
    public Vector3 lastCheckPointPos; //since this object isn't destroyed on scene reload, this variable will be available through respawns.
    void Awake() {

        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(instance);
        } else
        {
            Destroy(gameObject);
        }
    }
    void Update() {
        if ((Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl)) && Input.GetKeyDown(KeyCode.R)) // allows manual restarting of the game.
        {
            Debug.Log("ctr R");
            Debug.Log(GameObject.Find("Game Master").GetComponent<TimerController>().elapsedTime);
            GameObject.Find("Game Master").GetComponent<TimerController>().elapsedTime = 0f;
        }
        else if (Input.GetKeyDown(KeyCode.R)) {
            // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
