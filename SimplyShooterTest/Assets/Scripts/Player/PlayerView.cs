
using UnityEngine;
using UnityEngine.AI;
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
        ETouch.Touch.onFingerUp += Touch_onFingerUp;
    }
    private void OnDisable()
    {
        EnhancedTouchSupport.Disable();
        ETouch.Touch.onFingerDown -= HandelFingerDown;
        ETouch.Touch.onFingerMove -= HandelFingerMove;
        ETouch.Touch.onFingerUp -= Touch_onFingerUp;
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
        movementJoystick.SetKnobPosition(fingerMoved);
    }
    private void Touch_onFingerUp(Finger obj)
    {
        throw new System.NotImplementedException();
    }

    

    
}
