using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : UnitySingleton<LevelManager> {

    void Awake() {
        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    void Start() {
        LoadLevel("level1");
    }

    void LoadLevel(string levelName) {
        GameObject obj = Resources.Load<GameObject>("Prefabs/Level/" + levelName);
        GameObject tran = Instantiate(obj);
    }
}
