
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
        EventService.Instance.JoystickEnabled += () => { PlayerController.SetMovementAmount(Vector2.zero); };
        EventService.Instance.JoystickDisabled += () => { PlayerController.SetMovementAmount(Vector2.zero); };
        EventService.Instance.JoystickMoved += (joystick) => { PlayerController.SetMovementAmount(joystick.GetMovementAmount()); };
        EventService.Instance.WeaponPickedUp += PlayerController.ChangeWeapon;
        EventService.Instance.CoinCollected += PlayerController.IncreaseCoinCollected;
        EventService.Instance.EnemyDied += PlayerController.EmenyKilled;
        EventService.Instance.DoubleTapOnRightHalfOfScreen += TryToGoHypeMode;
        EventService.Instance.PlayerDataChanged += (playerData) => { if (playerData == playerScriptableObject) PlayerController.RefreshPlayerData(playerData); };
        EventService.Instance.PlayerLost += PlayerDied;
        EventService.Instance.PlayerWon += PlayerController.PlayerWon;
        
    }

    private void OnDisable()
    {
        EventService.Instance.JoystickEnabled -= () => { PlayerController.SetMovementAmount(Vector2.zero); };
        EventService.Instance.JoystickDisabled -= () => { PlayerController.SetMovementAmount(Vector2.zero); };
        EventService.Instance.JoystickMoved -= (joystick) => { PlayerController.SetMovementAmount(joystick.GetMovementAmount()); };
        EventService.Instance.WeaponPickedUp -= PlayerController.ChangeWeapon;
        EventService.Instance.CoinCollected -= PlayerController.IncreaseCoinCollected;
        EventService.Instance.EnemyDied -= PlayerController.EmenyKilled;
        EventService.Instance.DoubleTapOnRightHalfOfScreen -= TryToGoHypeMode;
        EventService.Instance.PlayerDataChanged -= (playerData) => { if (playerData == playerScriptableObject) PlayerController.RefreshPlayerData(playerData); };
        EventService.Instance.PlayerLost -= PlayerDied;
        EventService.Instance.PlayerWon -= PlayerController.PlayerWon;

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

    private void PlayerDied()
    {
        Destroy(gameObject);
    }

}
