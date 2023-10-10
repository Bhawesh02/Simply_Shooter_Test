
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;


public class PlayerView : MonoBehaviour
{
    [SerializeField]
    private JoystickController movementJoystick;
    [SerializeField]
    private NavMeshAgent navMeshAgent;
    private Finger movementFinger;
    private PlayerController playerController;
    private void Awake()
    {
        playerController = new();
    }
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
        if (movementFinger != null)
            return;
        movementFinger = fingerDown;
        playerController.SpawnJoystick(movementFinger,movementJoystick);
    }
    private void HandelFingerMove(Finger fingerMoved)
    {
        if(fingerMoved!=movementFinger) return;
        movementJoystick.SetKnobPositionToTouch(fingerMoved);
        playerController.SetMovementAmount(movementJoystick.GetMovementAmount());
    }
    private void HandelFingerUp(Finger lostFinger)
    {
        if(lostFinger!=movementFinger) return;
        movementFinger = null;
        movementJoystick.ResetJoystick();
        playerController.SetMovementAmount(Vector2.zero);
    }

    

    
}
