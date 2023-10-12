
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;

public class JoystickView : MonoBehaviour
{
    [HideInInspector]
    public RectTransform JoystickRectTransform;
    public RectTransform JoystickKnob;
    [HideInInspector]
    public Vector2 JoystickSize;

    private float maxKnobMovement;
    private void Awake()
    {
        JoystickRectTransform = GetComponent<RectTransform>();
        gameObject.SetActive(false);
        JoystickSize = JoystickRectTransform.sizeDelta;
        maxKnobMovement = JoystickSize.x / 2;
    }
    private void OnEnable()
    {
        EventService.Instance.InvokeJoystickEnabled();
    }
    private void OnDisable()
    {
        EventService.Instance.InvokeJoystickDisabled();
    }
    public void SetKnobPositionToTouch(Finger finger)
    {
        Vector2 knobPosittion;
        ETouch.Touch cuurentTouch = finger.currentTouch;
        if (Vector2.Distance(cuurentTouch.screenPosition, JoystickRectTransform.anchoredPosition) > maxKnobMovement)
        {
            knobPosittion = (cuurentTouch.screenPosition - JoystickRectTransform.anchoredPosition).normalized * maxKnobMovement;
        }
        else
        {
            knobPosittion = (cuurentTouch.screenPosition - JoystickRectTransform.anchoredPosition);
        }
        JoystickKnob.anchoredPosition = knobPosittion;
        EventService.Instance.InvokeJoystickMoved(this);
    }
    public Vector2 GetMovementAmount()
    {
        return JoystickKnob.anchoredPosition / maxKnobMovement;
    }
    public void ResetJoystick()
    {
        JoystickKnob.anchoredPosition = Vector2.zero;
        gameObject.SetActive(false);
    }
}
