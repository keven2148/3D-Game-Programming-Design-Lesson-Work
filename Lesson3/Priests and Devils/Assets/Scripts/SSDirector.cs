using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSDirector{

    private static SSDirector _Director; //静态成员保存了这个类的一个实例
    public ISceneController currentSceneController { get; set; } //这行和单例模式无关

    private SSDirector() {} //私有的构造函数确保他不能用new的方法创建实例
    //PS：千万不要在继承了MonoBehaviour的类下使用构造函数，他有两个生命周期，无法保证构造函数的这个方法可以正常使用

    //公有的静态函数instance()为整个代码库提供了一个获得该类的实例的方法
    public static SSDirector instance() {
        //如果实例还没有创建，那么就创建一个
        if (_Director == null) {
            _Director = new SSDirector();
        }
        //然后返回这个唯一的实例
        return _Director;
    } 
}
