
using System;
using Unity.VisualScripting.InputSystem;
using UnityEngine;

public class EventService : GenericSingleton<EventService>
{
    public event Action JoystickEnabled;
    public event Action JoystickDisabled;
    public event Action<JoystickView> JoystickMoved;
    public event Action<WeaponScritableObject> WeaponPickedUp;
    public event Action<PlayerScriptableObject> PlayerDataChanged;
    public event Action<EnemyScriptableObject> EnemyDataChanged;
    public event Action<EnemyView, float> EnemyDamaged;
    public event Action<EnemyView> EnemyDied;
    public event Action<CoinPickupView> CoinCollected;
    public event Action DoubleTapOnRightHalfOfScreen;
    public event Action HypeModeStarted;
    public event Action HypeModeEnded;
    public event Action PlayerLost;
    public event Action<EnemyView> EnemySpawned;
    public event Action PlayerEnteredFishLine;
    public event Action PlayerWon;

    public void InvokeJoystickEnabled()
    {
        JoystickEnabled?.Invoke();
    }
    public void InvokeJoystickDisabled()
    {
        JoystickDisabled?.Invoke();
    }
    public void InvokeJoystickMoved(JoystickView joystick)
    {
        JoystickMoved?.Invoke(joystick);
    }
    public void InvokeWeaponPickedUp(WeaponScritableObject weapon)
    {
        WeaponPickedUp?.Invoke(weapon);
    }
    public void InvokeEnemyDataChanged(EnemyScriptableObject enemy)
    {
        EnemyDataChanged?.Invoke(enemy);
    }
    public void InvokePlayerDataChanged(PlayerScriptableObject player)
    {
        PlayerDataChanged?.Invoke(player);
    }
    public void InvokeEnemyDamaged(EnemyView enemy, float damage)
    {
        EnemyDamaged?.Invoke(enemy, damage);
    }
    public void InokeEnemyDied(EnemyView enemy)
    {
        EnemyDied?.Invoke(enemy);
    }
    public void InvokeCoinCollected(CoinPickupView coin)
    {
        CoinCollected?.Invoke(coin);
    }
    public void InvokeDoubleTabOnRightHalfOfScrren()
    {
        DoubleTapOnRightHalfOfScreen?.Invoke();
    }
    public void InvokeHypeModeStarted()
    {
        HypeModeStarted?.Invoke();
    }
    public void InvokeHypeModeEnded()
    {
        HypeModeEnded?.Invoke();
    }
    public void InvokePlayerLost()
    {
        PlayerLost?.Invoke();
    }
    public void InvokeEnemySpawned(EnemyView enemyView)
    {
        EnemySpawned?.Invoke(enemyView);
    }
    public void InvokePlayerEnteredFinishLine()
    {
        PlayerEnteredFishLine?.Invoke();
    }
    public void InvokePlayerWon()
    {
        PlayerWon?.Invoke();
    }
}
