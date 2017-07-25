using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyReticle : MonoBehaviour {

    public Transform imageTrans;
    public Image image;
    public float distance;

    private Transform mainCamTrans;
    private Vector3 originalScale;

    private void Awake()
    {
        mainCamTrans = Camera.main.transform;
        originalScale = imageTrans.localScale;
    }

    //raycast没有射到物体。
    public void SetPosition()
    {
        imageTrans.position = mainCamTrans.position + mainCamTrans.forward * distance;

        imageTrans.localScale = originalScale * distance;

        image.color = Color.green;
    }

    //raycast射到物体。
    public void SetPosition(RaycastHit hit)
    {
        imageTrans.position = hit.point;

        imageTrans.localScale = originalScale * hit.distance;

        image.color = Color.red;
    }
}
