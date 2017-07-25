using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyVRRaycaster : MonoBehaviour {


    private Transform mainCamTrans;
    private MyVRInteractiveItem _prevVRII;
    private MyReticle _reticle;

    private void Start()
    {
        mainCamTrans = Camera.main.transform;
        _reticle = this.GetComponent<MyReticle>();
    }

    private void Update()
    {
        checkRaycast();
    }

    private void checkRaycast()
    {
        Ray ray = new Ray(mainCamTrans.position, mainCamTrans.forward);

        RaycastHit rayHit;
        if (Physics.Raycast(ray, out rayHit, Mathf.Infinity))
        {
            Collider currHitCol = rayHit.collider;
            MyVRInteractiveItem currVRII = currHitCol.GetComponent<MyVRInteractiveItem>();

            if (_prevVRII != currVRII)
            {
                if (_prevVRII != null) _prevVRII.Out();
            }
            else
            {
                //raycast 射到一个vrInteractiveItem.
                if (currVRII != null)
                {
                    currVRII.Over();
                    _reticle.SetPosition(rayHit);
                }
            }

            _prevVRII = currVRII;
        }
        else
        {
            _reticle.SetPosition();
            if (_prevVRII != null) _prevVRII.Out();
            _prevVRII = null;
        }
    }
}
