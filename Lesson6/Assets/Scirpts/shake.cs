using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shake : MonoBehaviour {

    public Transform transform;
    public float time = 0; //时长
    public float flood = 0; //幅度
    public float speed = 0; //速度

    private Vector2 dstpos;
    private Vector2 currentpos;
    private float curflood;
    private float curtime;

	void Start () {
        if (transform == null) {
            transform = this.GetComponent<Transform>();
        }

        currentpos = Vector2.zero;
        dstpos = currentpos;
        curflood = flood;
        curtime = time;
	}
	
	void Update () {
        if (curtime <= 0) return;
        curtime -= Time.deltaTime;

        float curspeed = speed * Time.deltaTime;
        curflood -= (Time.deltaTime / time) * flood; //减少振幅

        if (dstpos == currentpos) dstpos = Random.onUnitSphere * curflood; //如果停止，重新分配随机dst

        if (Vector2.Distance(dstpos, currentpos) > curspeed) 
            currentpos += (curspeed / Vector2.Distance(dstpos, currentpos)) * (dstpos - currentpos) ;
        else currentpos = dstpos;

        transform.rotation = Quaternion.Euler(new Vector3(currentpos.x, currentpos.y, 0) + transform.eulerAngles); //转动角度
	}
}
