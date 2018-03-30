using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Riverside { 
    Left,
    Right
};

public class Boat : MonoBehaviour , IObjectAction{

    public Transform[] seatPoints;
    public float speed = 1.0f;
    public bool[] isSeatEmpty; //位置是否有人
    public Riverside side; //船在哪一侧
    public int count; //船上有多少人
    public int manAndDevil = 0; //人和恶魔的差值，设人为1，恶魔为-1
    public GameController gameController;
    public bool isSwimming = false; //判断船是否在移动，移动中时不能上下船

    void Awake() {
        side = Riverside.Right;
        seatPoints = new Transform[transform.childCount];
        isSeatEmpty = new bool[transform.childCount];
        for (int i = 0; i < transform.childCount; i++) 
        {
            seatPoints[i] = transform.GetChild(i).transform;
            isSeatEmpty[i] = true;
        }
    }

    public void  excuse()
    {
        //船没有在移动，且船上有人，且游戏没有输掉也没有赢
        if (isSwimming == false && this.count != 0 && gameController.isLose == false && gameController.isWin == false)
        {
            if (this.side == Riverside.Left)
            {
                StartCoroutine(MoveToPosition(new Vector3(3f, 0.2f, 0f)));
                this.side = Riverside.Right;
                this.BroadcastMessage("ChangeSide", SendMessageOptions.DontRequireReceiver);
            }
            else
            {
                StartCoroutine(MoveToPosition(new Vector3(-3f, 0.2f, 0f)));
                this.side = Riverside.Left;
                this.BroadcastMessage("ChangeSide", SendMessageOptions.DontRequireReceiver);
            }
        }
    }

    IEnumerator MoveToPosition(Vector3 target) {
        while (transform.position != target) {
            isSwimming = true;
            transform.position = Vector3.MoveTowards(transform.position, target, 
                speed * Time.deltaTime * gameController.sceneController.sceneSpeed);
            yield return 0;
        }
        isSwimming = false;
        gameController.CheckGame();
        yield return 0;
    }
}
