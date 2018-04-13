using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalManager : UnitySingleton<TotalManager>{

    private TotalManager() { }

    void Awake() {
        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public LevelManager GetLevelManager() {
        return LevelManager.Instance();
    }

    public UIManager GetUIManager() {
        return UIManager.Instance();
    }
}
