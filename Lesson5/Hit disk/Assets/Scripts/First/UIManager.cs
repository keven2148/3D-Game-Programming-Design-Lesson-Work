using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : UnitySingleton<UIManager> {

    void Awake() {
        _instance = this;
        DontDestroyOnLoad(this.gameObject);

    }
}
