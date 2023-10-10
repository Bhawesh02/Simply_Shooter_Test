
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.UI;

public class JoystickController : MonoBehaviour
{
    [HideInInspector]
    public RectTransform JoystickRectTransform;
    public RawImage JoystickKnob;
    public Vector2 JoystickSize = new Vector2(300, 300);

    private void Awake()
    {
        JoystickRectTransform  = GetComponent<RectTransform>();
    }
    public void SetKnobPosition(Finger finger)
    {

    }
}
