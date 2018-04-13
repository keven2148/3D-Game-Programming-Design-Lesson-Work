using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskProductor : UnitySingleton<DiskProductor>{

    private DiskProductor() { }

    public static int POOL_SIZE = 20;
    private GameObject[] diskPool = new GameObject[POOL_SIZE];
    private GameObject firstAvailable;

    void Awake() {
        Init();
    }

    void Init() { 
        for (int i = 0; i < POOL_SIZE; i++) {
            GameObject obj = Instantiate(EnemyCreate.Instance().disk);
            obj.SetActive(false);
            diskPool[i] = obj;

            diskPool[i].GetComponent<Disk>().poolIndex = i;
            if (i == 0) continue;
            diskPool[i - 1].GetComponent<Disk>().nextDisk = diskPool[i];
        }
        diskPool[POOL_SIZE-1].GetComponent<Disk>().nextDisk = null;
        firstAvailable = diskPool[0];
    }

    public GameObject Create(Vector3 position, Vector3 velocity, float lifeTime) {
        //如果池子满了就随便抓一个丢出去，不保证效果
        if (firstAvailable == null) firstAvailable = diskPool[0];

        Disk _Disk = firstAvailable.GetComponent<Disk>();
        _Disk.init(position, velocity, lifeTime);
        firstAvailable.SetActive(true);
        firstAvailable = _Disk.nextDisk;
        return(_Disk.gameObject);
    }

    public void Return(int _index) {
        diskPool[_index].GetComponent<Disk>().nextDisk = firstAvailable;
        diskPool[_index].SetActive(false);
        firstAvailable = diskPool[_index];
    }

}
