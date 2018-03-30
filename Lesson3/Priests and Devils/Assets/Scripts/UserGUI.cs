using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserGUI : MonoBehaviour{

    private IUserAction action;
    private ISceneController controller;

    private bool isStart = false;
    private bool isPause = false;

    void Start() {
        action = SSDirector.instance().currentSceneController as IUserAction;
        controller = SSDirector.instance().currentSceneController as ISceneController;
    }

    void OnGUI() {
        if (isStart == false)
        {
            if (GUI.Button(new Rect(200, 200, 240, 80), "Start Game"))
            {
                controller.LoadResources();
                isStart = true;
            }
        }
        else {
            if (isPause == true) GUI.Label(new Rect(310, 400, 120, 20), "waiting!!!");
            if (GUI.Button(new Rect(570, 5, 60, 20), "Resume")) {
                controller.Resume();
                isPause = false;
            }
            if (GUI.Button(new Rect(505,5,60,20), "Pause")) {
                controller.Pause();
                isPause = true;
            }
            if (isPause == false) {
                if (GUI.Button(new Rect(5, 5, 100, 20), "Speed Up")) {
                    action.SpeedUp();
                }
                if (GUI.Button(new Rect(110, 5, 100, 20), "Speed Down"))
                {
                    action.SpeedDown();
                }
                if (GUI.Button(new Rect(215, 5, 100, 20), "Restart")) {
                    isStart = false; isPause = false;
                    action.GameOver();
                }
            }
        }
    }
}
