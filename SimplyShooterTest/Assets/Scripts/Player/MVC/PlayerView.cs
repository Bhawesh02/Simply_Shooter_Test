
using UnityEngine;
using UnityEngine.AI;


public class PlayerView : MonoBehaviour
{
    
    public NavMeshAgent NavMeshAgent;
    
    public PlayerController PlayerController;

    public WeaponScritableObject startWeapon;
    public LayerMask EnemyLayer;
    public float EnemyDetectionDelay = 0.1f;
    public EnemyView Enemy;

    private float nextEnemyDetectionTime;

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
        nextEnemyDetectionTime = Time.time;
        PlayerController.ChangeWeapon(startWeapon);
    }
    private void Update()
    {
        PlayerController.MovePlayer();
        if(Time.time >= nextEnemyDetectionTime)
        {
            PlayerController.DetectEnemy();
            nextEnemyDetectionTime = Time.time + EnemyDetectionDelay;
        }
    }

}
