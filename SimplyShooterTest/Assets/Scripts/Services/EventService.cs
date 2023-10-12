
using System;
using UnityEngine;

public class EventService : GenericSingleton<EventService>
{
    public event Action JoystickEnabled;
    public event Action JoystickDisabled;
    public event Action<JoystickController> JoystickMoved;
    public event Action<WeaponScritableObject> WeaponPickedUp;
    public event Action<EnemyScriptableObject> EnemyDataChanged;
    public event Action<EnemyView, float> EnemyDamaged;
    public event Action<EnemyView> EnemyDied;
    public event Action<CoinPickupController> CoinCollected;
    public event Action HypeModeStarted;
    public event Action HypeModeEnded;

    public void InvokeJoystickEnabled()
    {
        JoystickEnabled?.Invoke();
    }
    public void InvokeJoystickDisabled()
    {
        JoystickDisabled?.Invoke();
    }
    public void InvokeJoystickMoved(JoystickController joystick)
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
    public void InvokeEnemyDamaged(EnemyView enemy, float damage)
    {
        EnemyDamaged?.Invoke(enemy, damage);
    }
    public void InokeEnemyDied(EnemyView enemy)
    {
        EnemyDied?.Invoke(enemy);
    }
    public void InvokeCoinCollected(CoinPickupController coin)
    {
        CoinCollected?.Invoke(coin);
    }
    public void InvokeHypeModeStarted()
    {
        HypeModeStarted?.Invoke();
    }
    public void InvokeHypeModeEnded()
    {
        HypeModeEnded?.Invoke();
    }
}
