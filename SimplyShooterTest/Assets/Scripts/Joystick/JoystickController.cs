
using UnityEngine;
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
}
