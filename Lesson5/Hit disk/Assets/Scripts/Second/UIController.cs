using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : UnitySingleton<UIController>{

    private UIController() { }

    void OnGUI() {
        GUI.Label(new Rect(10, 10, 100, 20), "Round:" + (EnemyCreate.Instance().GetRoundIndex()+1));
    }
}
