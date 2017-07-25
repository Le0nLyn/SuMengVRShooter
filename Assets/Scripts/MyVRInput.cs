using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyVRInput : MonoBehaviour {

    public event Action OnButtonDown;
    public event Action OnButtonUp;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (OnButtonDown != null) OnButtonDown();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            if (OnButtonUp != null) OnButtonUp();
        }

    }
}
