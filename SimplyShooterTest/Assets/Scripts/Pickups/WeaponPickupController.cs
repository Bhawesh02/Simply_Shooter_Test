
using UnityEngine;

public class WeaponPickupController : PickupController
{
    public WeaponScritableObject weaponData;

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (player == null)
            return;
        EventService.Instance.InvokeWeaponPickedUp(weaponData);
        Destroy(gameObject);
    }

}
