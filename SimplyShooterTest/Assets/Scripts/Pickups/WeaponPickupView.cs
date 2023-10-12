
using UnityEngine;

public class WeaponPickupView : MonoBehaviour
{
    public WeaponScritableObject weaponData;

    private void OnTriggerEnter(Collider other)
    {
        PlayerView player = other.GetComponent<PlayerView>();
        if (player == null)
            return;
        EventService.Instance.InvokeWeaponPickedUp(weaponData);
        Destroy(gameObject);
    }

}
