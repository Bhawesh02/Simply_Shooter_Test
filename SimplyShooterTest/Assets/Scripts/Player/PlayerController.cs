
using System;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class PlayerController
{
    private Vector2 movementAmount;
    public void SpawnJoystick(Finger movementFinger, JoystickController joystick)
    {
        movementAmount = Vector2.zero;
        joystick.gameObject.SetActive(true);
        joystick.JoystickRectTransform.anchoredPosition = ClampPostion(movementFinger.screenPosition, joystick);
    }

    private Vector2 ClampPostion(Vector2 startPosition, JoystickController joystick)
    {
        if (startPosition.x < joystick.JoystickSize.x / 2)
        {
            startPosition.x = joystick.JoystickSize.x / 2;

        }
        else if (Screen.width - startPosition.x < joystick.JoystickSize.x / 2)
        {
            startPosition.x = Screen.width - joystick.JoystickSize.x / 2;
        }
        if(startPosition.y < joystick.JoystickSize.y / 2)
        {
            startPosition.y = joystick.JoystickSize.y / 2;

        }
        else if (Screen.height - startPosition.y < joystick.JoystickSize.y / 2)
        {
            startPosition.y = Screen.width - joystick.JoystickSize.y / 2;
        }
        return startPosition;
    }

    public void SetMovementAmount(Vector2 movAmt)
    {
        movementAmount = movAmt;
    }
}
