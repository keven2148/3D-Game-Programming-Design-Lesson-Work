using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : UnitySingleton<Shoot> {

    private Shoot() { }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            bool isCollider = Physics.Raycast(ray, out hit);
            //击中了一个collider
            if (isCollider) {
                Debug.Log("hit");
                if (hit.transform.tag == "Disk") {
                    hit.transform.GetComponent<Disk>().DestroyItSelf();
                }
            }
        }
    }
}
