using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour {

    Manager gameManager;

    void Start() 
    {
        gameManager = GameObject.Find("Manager").GetComponent<Manager>();
    }

    void OnGUI() 
    {
        if (GUI.Button(new Rect(280,450,80,20), "Restart"))
        {
            gameManager.OnReStart();
        }
    }
}
