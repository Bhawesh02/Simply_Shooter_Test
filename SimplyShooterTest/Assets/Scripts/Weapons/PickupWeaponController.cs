
using UnityEngine;

public class PickupWeaponController : MonoBehaviour
{
    public WeaponScritableObject weaponData;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(weaponData.WeaponType);
        PlayerView player = other.gameObject.transform.root.GetComponent<PlayerView>();
        if (player == null)
            return;
        EventService.Instance.InvokeWeaponPickedUp(weaponData);
        Destroy(gameObject);
    }
}