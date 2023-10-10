
using UnityEngine;
using UnityEngine.AI;


public class PlayerView : MonoBehaviour
{
    
    public NavMeshAgent NavMeshAgent;
    
    public PlayerController PlayerController;

    public WeaponScritableObject startWeapon;
    public LayerMask EnemyLayer;
    public EnemyView Enemy;


    public WeaponContainer WeaponContainer;

    private void Awake()
    {
        PlayerController = new(this);
        EventService.Instance.JoystickEnabled += () => { PlayerController.SetMovementAmount(Vector2.zero); };
        EventService.Instance.JoystickDisabled += () => { PlayerController.SetMovementAmount(Vector2.zero); };
        EventService.Instance.JoystickMoved += (joystick) => { PlayerController.SetMovementAmount(joystick.GetMovementAmount()); };
        EventService.Instance.WeaponPickedUp += (weaponData) => { PlayerController.ChangeWeapon(weaponData); };
    }
    private void OnDestroy()
    {
        EventService.Instance.JoystickEnabled -= () => { PlayerController.SetMovementAmount(Vector2.zero); };
        EventService.Instance.JoystickDisabled -= () => { PlayerController.SetMovementAmount(Vector2.zero); };
        EventService.Instance.JoystickMoved -= (joystick) => { PlayerController.SetMovementAmount(joystick.GetMovementAmount()); };
        EventService.Instance.WeaponPickedUp -= (weaponData) => { PlayerController.ChangeWeapon(weaponData); };
    }
    private void Start()
    {
        PlayerController.ChangeWeapon(startWeapon);
    }
    private void Update()
    {
        PlayerController.MovePlayer();
        PlayerController.EnemyFightAI();
    }

}
