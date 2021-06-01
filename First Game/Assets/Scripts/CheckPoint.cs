using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private GameMaster gm;

    void Start() {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>(); 
    }
    // Start is called before the first frame update
    
    
     // when this checkpoint object is colliding with something else (tag==player):
     //it will store its position as next respawn position within the gamemaster object so that value will survive scene restarts
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) { // jumpboost
            Debug.Log("touched");
            gm.lastCheckPointPos = transform.position;

        }
    }
}
