using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land : MonoBehaviour {

    public Transform[] seatPoints;
    public bool[] isSeatEmpty;
    public Riverside side;
    public int count; //岸上有多少人
    public int manAndDevil = 0; //人和魔鬼的差值

    void Awake()
    {
        seatPoints = new Transform[transform.childCount];
        isSeatEmpty = new bool[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            seatPoints[i] = transform.GetChild(i).transform;
            if (side == Riverside.Right) isSeatEmpty[i] = false;
            else isSeatEmpty[i] = true;
        }
        if (side == Riverside.Right) count = 6;
        else count = 0;
    }
}
