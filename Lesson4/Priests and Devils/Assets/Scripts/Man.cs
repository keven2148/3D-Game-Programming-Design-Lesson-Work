using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Man : MonoBehaviour , IObjectAction{

    public GameController gameController;
    public Riverside side;
    public int index;
    private bool _isOnBoat = false;
    public int charactor = 0;  //标记是人还是恶魔，人为1，魔鬼为-1

    public bool isOnBoat
    {
        get;
        set;
    }

    /* public void excuse() {
    public void excuse() {
        Debug.Log(this.name + "is excusing");
        //如果物体和船在同一侧才能操作
        Debug.Log(this.side);
        Debug.Log(gameController.boat.side);
        //船不在移动，且游戏没有输时才可以对人进行操作
        if (gameController.boat.isSwimming == false && gameController.isLose == false)
        {
            if (this.side == gameController.boat.side)
            {
                Debug.Log(this.name + "on the same side");
                if (isOnBoat == false && gameController.boat.count < 2) //如果人在岸上且船未满
                {
                    Debug.Log(this.name + "is get on the boat");
                    for (int i = 0; i < gameController.boat.isSeatEmpty.Length; i++)
                    {
                        if (gameController.boat.isSeatEmpty[i] == true) //找到一个空位置做进去
                        {
                            Debug.Log("find this seat: " + i);
                            this.transform.position = gameController.boat.seatPoints[i].position;
                            transform.SetParent(gameController.boat.transform);
                            gameController.GetCurrentLandSide(this.side).GetComponent<Land>().isSeatEmpty[index] = true;
                            gameController.boat.isSeatEmpty[i] = false;
                            index = i;
                            isOnBoat = true;

                            gameController.GetCurrentLandSide(this.side).GetComponent<Land>().count--;
                            gameController.GetCurrentLandSide(this.side).GetComponent<Land>().manAndDevil -= this.charactor;
                            gameController.boat.count++;
                            gameController.boat.manAndDevil += this.charactor;
                            break;
                        }
                    }
                }
                else if (isOnBoat == true)
                { //如果人在船上
                    Land currentLandSide = gameController.GetCurrentLandSide(gameController.boat.side).GetComponent<Land>();
                    Debug.Log("current Land Side is " + currentLandSide.side);
                    for (int i = 0; i < currentLandSide.isSeatEmpty.Length; i++)
                    {
                        if (currentLandSide.isSeatEmpty[i] == true)
                        { //找到岸上的一个空位置坐进去
                            this.transform.position = currentLandSide.seatPoints[i].position;
                            this.transform.SetParent(currentLandSide.transform);
                            gameController.boat.isSeatEmpty[index] = true;
                            currentLandSide.isSeatEmpty[i] = false;
                            index = i;

                            gameController.GetCurrentLandSide(this.side).GetComponent<Land>().count++;
                            gameController.GetCurrentLandSide(this.side).GetComponent<Land>().manAndDevil += this.charactor;
                            gameController.boat.manAndDevil -= this.charactor;
                            gameController.boat.count--;
                            isOnBoat = false;
                            break;
                        }
                    }
                }
            }
        }
    }
    */
    
    public void ChangeSide() {
        if (side == Riverside.Left) side = Riverside.Right;
        else side = Riverside.Left;

        
    }

    public void  Accept(Visitor _visitor)
    {
        _visitor.VisitMan(this);
    }
}
