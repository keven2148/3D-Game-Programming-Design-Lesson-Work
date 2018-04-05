using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Visitor{

    public abstract void VisitMan(Man Element);

    public abstract void VisitBoat(Boat Element);

}
