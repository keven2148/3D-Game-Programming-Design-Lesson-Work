using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//FirstController类继承了2个接口
public class FirstController : MonoBehaviour, ISceneController , IUserAction{ 

    GameObject currentScene = null;
    public float sceneSpeed = 1.0f;

    private bool isGameOver = false;

    void Awake() {
        //将Director的接口引用 的目标改成自己
        SSDirector.instance().currentSceneController = this;
    }

    public void LoadResources()
    {
        currentScene = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Scene"));
        currentScene.GetComponent<GameController>().sceneController = this;
    }

    public void Resume()
    {
        sceneSpeed = 1.0f;
    }

    public void Pause()
    {
        sceneSpeed = 0f;
    }

    public void SpeedUp()
    {
        sceneSpeed += 0.5f;
    }

    public void SpeedDown()
    {
        sceneSpeed -= 0.5f;
        if (sceneSpeed < 0) sceneSpeed = 0;
    }

    public void GameOver()
    {
        Destroy(currentScene);
        isGameOver = false;
    }

    void OnGUI() {
        if (isGameOver == true)
        {
            GUI.Label(new Rect(310, 500, 120, 20), "waiting!!!");
        }
    }
}
