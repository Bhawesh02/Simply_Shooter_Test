
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
