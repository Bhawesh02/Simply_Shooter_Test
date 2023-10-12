
using System;
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
    private Coroutine HypeModeCoroutine;

    private void Awake()
    {
        PlayerController = new(this);   
    }
    private void Start()
    {
        PlayerController.ChangeWeapon(startWeapon);
        EventService.Instance.DoubleTapOnRightHalfOfScreen += TryToGoHypeMode;
    }
    private void OnDestroy()
    {
        EventService.Instance.DoubleTapOnRightHalfOfScreen -= TryToGoHypeMode;
    }
    private void TryToGoHypeMode()
    {
        if (PlayerController.GetInHypeMode() || PlayerController.GetHowMuchHypeIsCharged() != 1f)
            return;
        HypeModeCoroutine = StartCoroutine(PlayerController.HypeMode());
    }

    private void Update()
    {
        PlayerController.MovePlayer();
        PlayerController.EnemyFightAI();
    }

}
