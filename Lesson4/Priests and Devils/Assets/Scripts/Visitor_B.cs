using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visitor_B : Visitor {

    public override void VisitMan(Man Element)
    {
        Debug.Log("We right click on the Man!!!!");
    }

    public override void VisitBoat(Boat Element)
    {
        Debug.Log("We right click on the Boat!!!!");
    }
}
