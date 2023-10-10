
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;


public class PlayerView : MonoBehaviour
{
    
    public NavMeshAgent NavMeshAgent;
    
    private PlayerController playerController;
    private void Awake()
    {
        playerController = new(this);
        EventService.Instance.JoystickEnabled += () => { playerController.SetMovementAmount(Vector2.zero); };
        EventService.Instance.JoystickDisabled += () => { playerController.SetMovementAmount(Vector2.zero); };
        EventService.Instance.JoystickMoved += (joystick) => { playerController.SetMovementAmount(joystick.GetMovementAmount()); };
    }
    private void OnDestroy()
    {
        EventService.Instance.JoystickEnabled -= () => { playerController.SetMovementAmount(Vector2.zero); };
        EventService.Instance.JoystickDisabled -= () => { playerController.SetMovementAmount(Vector2.zero); };
        EventService.Instance.JoystickMoved += (joystick) => { playerController.SetMovementAmount(joystick.GetMovementAmount()); };
    }

    private void Update()
    {
        playerController.MovePlayer();
    }


}
