
using UnityEngine;

public class PickupController : MonoBehaviour
{
    protected PlayerView player;
    protected virtual void OnTriggerEnter(Collider other)
    {
        player = other.gameObject.GetComponent<PlayerView>();
    }
}
