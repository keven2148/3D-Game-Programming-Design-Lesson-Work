using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public Boat boat;
    public GameObject leftLand;
    public GameObject rightLand;
    public FirstController sceneController;
    public bool isLose = false;
    public bool isWin = false;

    public GameObject GetCurrentLandSide(Riverside _side) {
        if (_side == Riverside.Left) return leftLand;
        else return rightLand;
    }

    public void CheckGame() {
        int _leftCount = leftLand.GetComponent<Land>().count;
        int _leftManAndDevil = leftLand.GetComponent<Land>().manAndDevil;
        int _rightCount = rightLand.GetComponent<Land>().count;
        int _rightManAndDevil = rightLand.GetComponent<Land>().manAndDevil;

        if (boat.side == Riverside.Left)
        {
            _leftCount += boat.count;
            _leftManAndDevil += boat.manAndDevil;
        }
        else {
            _rightCount += boat.count;
            _rightManAndDevil += boat.manAndDevil;
        }

        //if (_leftCount == 3 && _leftManAndDevil == -3) isLose = true;
        if (_leftCount == 6) isWin = true;

        CheckSide(_leftCount, _leftManAndDevil);
        CheckSide(_rightCount, _rightManAndDevil);
    }

    private void CheckSide(int _count, int _manAndDevil) {
        if (_manAndDevil < 0 && Mathf.Abs(_manAndDevil) != _count)
            isLose = true;
    }

    void OnGUI() {
        if (isLose == true) {
            GUI.Label(new Rect(300,100,100,20),"YOU LOSE!!!!!!!");
        }
        if (isWin == true) {
            GUI.Label(new Rect(300, 100, 100, 20), "YOU WIN!!!!!!!");
        }
    }
}
