
using UnityEngine;
using UnityEngine.AI;


public class PlayerView : MonoBehaviour
{
    
    public NavMeshAgent NavMeshAgent;
    
    public PlayerController PlayerController;

    public float AttackRange;
    public LayerMask EnemyLayer;
    public float EnemyDetectionDelay = 0.1f;
    public EnemyView Enemy;

    private float nextEnemyDetectionTime;

    private void Awake()
    {
        PlayerController = new(this);
        EventService.Instance.JoystickEnabled += () => { PlayerController.SetMovementAmount(Vector2.zero); };
        EventService.Instance.JoystickDisabled += () => { PlayerController.SetMovementAmount(Vector2.zero); };
        EventService.Instance.JoystickMoved += (joystick) => { PlayerController.SetMovementAmount(joystick.GetMovementAmount()); };
    }
    private void OnDestroy()
    {
        EventService.Instance.JoystickEnabled -= () => { PlayerController.SetMovementAmount(Vector2.zero); };
        EventService.Instance.JoystickDisabled -= () => { PlayerController.SetMovementAmount(Vector2.zero); };
        EventService.Instance.JoystickMoved += (joystick) => { PlayerController.SetMovementAmount(joystick.GetMovementAmount()); };
    }
    private void Start()
    {
        nextEnemyDetectionTime = Time.time;
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
