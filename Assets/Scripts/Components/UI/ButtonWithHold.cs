using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonWithHold : Button
{
    public bool IsHeld = false;
    // Button is Pressed
    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        IsHeld = true;
    }

    // Button is released
    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        IsHeld = false;
    }
}