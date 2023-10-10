
using UnityEngine;
using UnityEngine.UI;

public class JoystickController : MonoBehaviour
{
    [HideInInspector]
    public RectTransform JoystickRectTransform;
    public RawImage JoystickKnob;

    private void Awake()
    {
        JoystickRectTransform  = GetComponent<RectTransform>();
    }
}
