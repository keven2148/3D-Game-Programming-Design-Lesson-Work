using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct RoundData { 
    public float Speed;
    public float random;
};

public class EnemyCreate : UnitySingleton<EnemyCreate>{

    private EnemyCreate() { }

    //ROUND数
    public static int roundNumber = 10;
    public RoundData[] Round = new RoundData[roundNumber];
    //一个Round有多少个碟子
    public static int countNumber = 10;
    //计时和下一个的射击间隔
    private float time;
    private float nexttime;
    //当前是第几count和第几Round
    [SerializeField] private int roundIndex;
    [SerializeField] private int countIndex;
    //disk的prefabs
    public GameObject disk;
    //发射盒,应该是要写个脚本比较方便的，不过简单写写就算了
    public Transform lunchPosition;

    void Awake() {
        _instance = this;
        time = 0; nexttime = 0; roundIndex = 0; countIndex = 0;
        DiskProductor ini = DiskProductor.Instance(); //初始化碟子工厂
    }

    void Update() {
        time += Time.deltaTime;

        if (nexttime == 0) {
            nexttime = Round[roundIndex].Speed + Random.Range(-Round[roundIndex].random, Round[roundIndex].random);
        }

        if (time < nexttime) return;
        countIndex++;
        CreateDisk();
        time -= nexttime;
        nexttime = 0;
        if (countIndex < countNumber) return;
        countIndex = 0; roundIndex++;
    }

    void CreateDisk() {
        Vector3 _position = lunchPosition.position + new Vector3(Random.Range(-2,2), Random.Range(-2,2), Random.Range(-2, 2));
        Vector3 _velocity = new Vector3(-1f, Random.Range(-0.125f, 0.125f), 0);
        GameObject obj = DiskProductor.Instance().Create(_position, _velocity, 15f);
    }

    public int GetRoundIndex() {
        return roundIndex;
    }
}
