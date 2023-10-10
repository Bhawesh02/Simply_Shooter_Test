
using System;
using UnityEngine;

public class EventService : GenericSingleton<EventService>
{
    public event Action JoystickEnabled;
    public event Action JoystickDisabled;

    public void InvokeJoystickEnabled()
    {
        JoystickEnabled?.Invoke();
    }
    public void InvokeJoystickDisabled()
    {
        JoystickDisabled?.Invoke();
    }
}
