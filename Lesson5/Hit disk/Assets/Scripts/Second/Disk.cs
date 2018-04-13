using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disk : MonoBehaviour {

    private float timeLeft;
    private Vector3 velocity;

    public GameObject nextDisk;
    public int poolIndex;

    void Awake() {
        timeLeft = 0;
    }

    public void init(Vector3 _position, Vector3 _velocity, float _lifeTime) {
        this.transform.position = _position;
        timeLeft = _lifeTime;
        velocity = _velocity;
    }

    void Update() {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0) DestroyItSelf();
        else
        {
            this.transform.position += velocity * Time.deltaTime;
        }
    }

    public void DestroyItSelf() {
        DiskProductor.Instance().Return(poolIndex);
    }
}
