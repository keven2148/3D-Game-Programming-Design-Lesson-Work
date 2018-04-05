using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectAction{
    void Accept(Visitor _visitor);
}
