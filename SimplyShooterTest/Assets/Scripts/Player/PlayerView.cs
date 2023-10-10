
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;


public class PlayerView : MonoBehaviour
{
    public JoystickController MovementJoystick;
    public NavMeshAgent NavMeshAgent;
    public Finger MovementFinger;
    private PlayerController playerController;
    private void Awake()
    {
        playerController = new(this);
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
        if (MovementFinger != null)
            return;
        MovementFinger = fingerDown;
        playerController.SpawnJoystick();
    }
    private void HandelFingerMove(Finger fingerMoved)
    {
        if(fingerMoved!=MovementFinger) return;
        MovementJoystick.SetKnobPositionToTouch(fingerMoved);
        playerController.SetMovementAmount(MovementJoystick.GetMovementAmount());
    }
    private void HandelFingerUp(Finger lostFinger)
    {
        if(lostFinger!=MovementFinger) return;
        MovementFinger = null;
        MovementJoystick.ResetJoystick();
        playerController.SetMovementAmount(Vector2.zero);
    }

    private void Update()
    {
        playerController.MovePlayer();
    }


}
