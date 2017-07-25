using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MyVRUIButton : MonoBehaviour
{

    private MyVRInteractiveItem vrii;
    private PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
    private Button button;
    private MyVRInput vrInput;

    private void Awake()
    {
        vrii = this.GetComponent<MyVRInteractiveItem>();
        button = this.GetComponent<Button>();
        vrInput = FindObjectOfType<MyVRInput>();

        vrii.OnOver += Vrii_OnOver;
        vrii.OnOut += Vrii_OnOut;
        vrInput.OnButtonDown += VrInput_OnButtonDown;
        vrInput.OnButtonUp += VrInput_OnButtonUp;
    }

    private void VrInput_OnButtonUp()
    {
        if (vrii.isOver)
        {
            ExecuteEvents.Execute(button.gameObject, pointerEventData, ExecuteEvents.pointerUpHandler);
            ExecuteEvents.Execute(button.gameObject, pointerEventData, ExecuteEvents.submitHandler);
        }
    }

    private void VrInput_OnButtonDown()
    {
        if (vrii.isOver)
            ExecuteEvents.Execute(button.gameObject, pointerEventData, ExecuteEvents.pointerDownHandler);
    }

    private void Vrii_OnOut()
    {
        ExecuteEvents.Execute(button.gameObject, pointerEventData, ExecuteEvents.pointerExitHandler);
    }

    private void Vrii_OnOver()
    {
        ExecuteEvents.Execute(button.gameObject, pointerEventData, ExecuteEvents.pointerEnterHandler);
    }
}
