using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Use this script to check if you're hover, click, drag, etc on a button / object.
/// </summary>
public class ButtonState : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    private bool isHovering;

    private void Start()
    {
        isHovering = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
    }    

    public bool OnHover()
    {
        return isHovering;
    }

}
