using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visitor_A : Visitor{

    public override void VisitMan(Man Element)
    {
        //Debug.Log(Element.name + "is excusing");
        //如果物体和船在同一侧才能操作
        //Debug.Log(Element.side);
        //Debug.Log(Element.gameController.boat.side);
        //船不在移动，且游戏没有输时才可以对人进行操作
        if (Element.gameController.boat.isSwimming == false && Element.gameController.isLose == false)
        {
            if (Element.side == Element.gameController.boat.side)
            {
                //Debug.Log(Element.name + "on the same side");
                if (Element.isOnBoat == false && Element.gameController.boat.count < 2) //如果人在岸上且船未满
                {
                    //Debug.Log(Element.name + "is get on the boat");
                    for (int i = 0; i < Element.gameController.boat.isSeatEmpty.Length; i++)
                    {
                        if (Element.gameController.boat.isSeatEmpty[i] == true) //找到一个空位置做进去
                        {
                            //Debug.Log("find this seat: " + i);
                            Element.transform.position = Element.gameController.boat.seatPoints[i].position;
                            Element.transform.SetParent(Element.gameController.boat.transform);
                            Element.gameController.GetCurrentLandSide(Element.side).GetComponent<Land>().isSeatEmpty[Element.index] = true;
                            Element.gameController.boat.isSeatEmpty[i] = false;
                            Element.index = i;
                            Element.isOnBoat = true;

                            Element.gameController.GetCurrentLandSide(Element.side).GetComponent<Land>().count--;
                            Element.gameController.GetCurrentLandSide(Element.side).GetComponent<Land>().manAndDevil -= Element.charactor;
                            Element.gameController.boat.count++;
                            Element.gameController.boat.manAndDevil += Element.charactor;
                            break;
                        }
                    }
                }
                else if (Element.isOnBoat == true)
                { //如果人在船上
                    Land currentLandSide = Element.gameController.GetCurrentLandSide(Element.gameController.boat.side).GetComponent<Land>();
                    //Debug.Log("current Land Side is " + currentLandSide.side);
                    for (int i = 0; i < currentLandSide.isSeatEmpty.Length; i++)
                    {
                        if (currentLandSide.isSeatEmpty[i] == true)
                        { //找到岸上的一个空位置坐进去
                            Element.transform.position = currentLandSide.seatPoints[i].position;
                            Element.transform.SetParent(currentLandSide.transform);
                            Element.gameController.boat.isSeatEmpty[Element.index] = true;
                            currentLandSide.isSeatEmpty[i] = false;
                            Element.index = i;

                            Element.gameController.GetCurrentLandSide(Element.side).GetComponent<Land>().count++;
                            Element.gameController.GetCurrentLandSide(Element.side).GetComponent<Land>().manAndDevil += Element.charactor;
                            Element.gameController.boat.manAndDevil -= Element.charactor;
                            Element.gameController.boat.count--;
                            Element.isOnBoat = false;
                            break;
                        }
                    }
                }
            }
        }
    }

    public override void VisitBoat(Boat Element)
    {
        //船没有在移动，且船上有人，且游戏没有输掉也没有赢
        if (Element.isSwimming == false && Element.count != 0 && Element.gameController.isLose == false && Element.gameController.isWin == false)
        {
            if (Element.side == Riverside.Left)
            {
                Element.MoveToPosition(new Vector3(3f, 0.2f, 0f));
                Element.side = Riverside.Right;
                Element.BroadcastMessage("ChangeSide", SendMessageOptions.DontRequireReceiver);
            }
            else
            {
                Element.MoveToPosition(new Vector3(-3f, 0.2f, 0f));
                Element.side = Riverside.Left;
                Element.BroadcastMessage("ChangeSide", SendMessageOptions.DontRequireReceiver);
            }
        }
    }

}
