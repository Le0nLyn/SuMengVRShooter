using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyVRInteractiveItem : MonoBehaviour {

    public event Action OnOver; //指针在物体上
    public event Action OnOut;  //指针离开物体。


    public bool isOver;

    

    public void Over()
    {
        isOver = true;
        if (OnOver != null) OnOver();
    }

    public void Out()
    {
        isOver = false;
        if (OnOut != null) OnOut();
    }

}
