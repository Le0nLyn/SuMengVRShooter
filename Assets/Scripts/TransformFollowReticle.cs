using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformFollowReticle : MonoBehaviour {

    
    public Transform reticleTransform;
    public Vector3 defaultOffsetPosition;
    private Transform mainCamTrans;

    private void Awake()
    {
        mainCamTrans = Camera.main.transform;

    }

    private void Update()
    {
        this.transform.position = mainCamTrans.position + mainCamTrans.localRotation * defaultOffsetPosition;
        Vector3 forward = reticleTransform.position - this.transform.position;
        this.transform.forward = forward;
    }
}
