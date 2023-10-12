
using System;
using UnityEngine;
using UnityEngine.AI;


public class PlayerView : MonoBehaviour
{

    public NavMeshAgent NavMeshAgent;
    [SerializeField]
    private PlayerScriptableObject playerScriptableObject;
    public PlayerController PlayerController;

    public WeaponScritableObject startWeapon;
    public LayerMask EnemyLayer;
    public EnemyView Enemy;
    public WeaponContainer WeaponContainer;
    private Coroutine HypeModeCoroutine;

    private void Awake()
    {
        PlayerController = new(this, playerScriptableObject);
    }
    private void Start()
    {
        PlayerController.ChangeWeapon(startWeapon);
        EventService.Instance.DoubleTapOnRightHalfOfScreen += TryToGoHypeMode;
        EventService.Instance.PlayerDataChanged += (playerData) => { if (playerData == playerScriptableObject) PlayerController.RefreshPlayerData(playerData); };
    }
    private void OnDestroy()
    {
        EventService.Instance.DoubleTapOnRightHalfOfScreen -= TryToGoHypeMode;
        EventService.Instance.PlayerDataChanged -= (playerData) => { if (playerData == playerScriptableObject) PlayerController.RefreshPlayerData(playerData); };
        StopAllCoroutines();
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
