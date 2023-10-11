
using System;

public class EventService : GenericSingleton<EventService>
{
    public event Action JoystickEnabled;
    public event Action JoystickDisabled;
    public event Action<JoystickController> JoystickMoved;
    public event Action<WeaponScritableObject> WeaponPickedUp;
    public event Action<EnemyScriptableObject> EnemyDataChanged;
    public event Action<EnemyView, float> EnemyDamaged;
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
    public void InvokeEnemyDamaged(EnemyView enemy,float damage)
    {
        EnemyDamaged?.Invoke(enemy, damage);
    }
}
