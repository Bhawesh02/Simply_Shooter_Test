
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;


public class TouchInputService : MonoGenericSingelton<TouchInputService>
{
    public JoystickController MovementJoystick;
    public Finger MovementFinger;

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
        ETouch.Touch.onFingerDown += HandelFingerDown;
        ETouch.Touch.onFingerMove += HandelFingerMove;
        ETouch.Touch.onFingerUp += HandelFingerUp;
    }
    private void OnDisable()
    {
        ETouch.Touch.onFingerDown -= HandelFingerDown;
        ETouch.Touch.onFingerMove -= HandelFingerMove;
        ETouch.Touch.onFingerUp -= HandelFingerUp;
        EnhancedTouchSupport.Disable();
    }
    private void HandelFingerDown(Finger fingerDown)
    {
        if (MovementFinger != null)
            return;
        MovementFinger = fingerDown;
        SpawnJoystick();
    }
    private void HandelFingerMove(Finger fingerMoved)
    {
        if (fingerMoved != MovementFinger) return;
        MovementJoystick.SetKnobPositionToTouch(fingerMoved);

    }
    private void HandelFingerUp(Finger lostFinger)
    {
        if (lostFinger != MovementFinger) return;
        MovementFinger = null;
        MovementJoystick.ResetJoystick();
    }

    public void SpawnJoystick()
    {
        MovementJoystick.gameObject.SetActive(true);
        MovementJoystick.JoystickRectTransform.anchoredPosition = ClampPostion(MovementFinger.screenPosition, MovementJoystick);
    }

    private Vector2 ClampPostion(Vector2 startPosition, JoystickController joystick)
    {
        if (startPosition.x < joystick.JoystickSize.x / 2)
        {
            startPosition.x = joystick.JoystickSize.x / 2;

        }
        else if (Screen.width - startPosition.x < joystick.JoystickSize.x )
        {
            startPosition.x = Screen.width - joystick.JoystickSize.x ;
        }
        if (startPosition.y < joystick.JoystickSize.y / 2)
        {
            startPosition.y = joystick.JoystickSize.y / 2;

        }
        else if (Screen.height - startPosition.y < joystick.JoystickSize.y )
        {
            startPosition.y = Screen.width - joystick.JoystickSize.y ;
        }
        return startPosition;
    }

}
