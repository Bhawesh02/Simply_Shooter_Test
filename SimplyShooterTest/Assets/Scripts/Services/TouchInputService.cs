
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;


public class TouchInputService : MonoGenericSingelton<TouchInputService>
{
    public JoystickView MovementJoystick;
    public Finger MovementFinger;
    private Finger TapFinger;
    [SerializeField]
    private float maxTapDelay;
    private int tapCount = 0;
    private Coroutine resetTapCoroutine;
    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
        ETouch.Touch.onFingerDown += HandelFingerDown;
        ETouch.Touch.onFingerMove += HandelFingerMove;
        ETouch.Touch.onFingerUp += HandelFingerUp;
        EventService.Instance.PlayerWon += DisableTouch;
        EventService.Instance.PlayerLost += DisableTouch;
    }


    private void OnDisable()
    {
        ETouch.Touch.onFingerDown -= HandelFingerDown;
        ETouch.Touch.onFingerMove -= HandelFingerMove;
        ETouch.Touch.onFingerUp -= HandelFingerUp;
        EventService.Instance.PlayerWon -= DisableTouch;
        EventService.Instance.PlayerLost -= DisableTouch;
        if(MovementJoystick!=null)
        MovementJoystick.gameObject.SetActive(false);
        EnhancedTouchSupport.Disable();
    }

    private void HandelFingerDown(Finger fingerDown)
    {
        if (fingerDown.screenPosition.x > Screen.width / 2f)
        {
            if (resetTapCoroutine != null)
                StopCoroutine(resetTapCoroutine);
            TapFinger = fingerDown;
            tapCount++;
            if (tapCount == 2)
            {
                EventService.Instance.InvokeDoubleTabOnRightHalfOfScrren();
                tapCount = 0;
            }
            return;
        }
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
        if (lostFinger == TapFinger)
            resetTapCoroutine = StartCoroutine(ResetTap());
        if (lostFinger != MovementFinger) return;
        MovementFinger = null;
        MovementJoystick.ResetJoystick();
    }

    public void SpawnJoystick()
    {
        MovementJoystick.gameObject.SetActive(true);
        MovementJoystick.JoystickRectTransform.anchoredPosition = ClampPostion(MovementFinger.screenPosition, MovementJoystick);
    }

    private Vector2 ClampPostion(Vector2 startPosition, JoystickView joystick)
    {
        if (startPosition.x < joystick.JoystickSize.x / 2)
        {
            startPosition.x = joystick.JoystickSize.x / 2;

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

    private IEnumerator ResetTap()
    {
        yield return new WaitForSeconds(maxTapDelay);
        tapCount = 0;
    }

    private void DisableTouch()
    {
        this.enabled = false;
    }
}
