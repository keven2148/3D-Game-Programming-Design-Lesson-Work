using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//处理鼠标输入点击
public class InputController : MonoBehaviour {

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
        //如果鼠标左键有点击
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            bool isCollider = Physics.Raycast(ray, out hit); 
            //射线与collider发生了碰撞
            if (isCollider) {
                //hit.transform.gameObject.SendMessage("excuse", SendMessageOptions.DontRequireReceiver);
                IObjectAction _temp = hit.transform.GetComponent<IObjectAction>(); //获取碰撞物体上的继承了IObjectAciton接口的组件
                if (_temp != null) _temp.excuse(); //如果非空，则代表这个物体上有我们需要的组件，就使用
            }
        }
    }
}
