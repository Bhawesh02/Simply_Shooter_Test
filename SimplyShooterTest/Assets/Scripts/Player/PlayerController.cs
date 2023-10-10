
using UnityEngine;

public class PlayerController
{
    private Vector2 movementAmount;
    private PlayerView playerView;
    public PlayerController(PlayerView view)
    {
        playerView = view;
    }
    public void SpawnJoystick()
    {
        movementAmount = Vector2.zero;
        playerView.MovementJoystick.gameObject.SetActive(true);
        playerView.MovementJoystick.JoystickRectTransform.anchoredPosition = ClampPostion(playerView.MovementFinger.screenPosition, playerView.MovementJoystick);
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

    public void MovePlayer()
    {
        Vector3 scaledMovement = playerView.NavMeshAgent.speed * Time.deltaTime * new Vector3(movementAmount.x,0,movementAmount.y);
        playerView.transform.LookAt(playerView.transform.position + scaledMovement,Vector3.up);
        playerView.NavMeshAgent.Move(scaledMovement);
    }
}
