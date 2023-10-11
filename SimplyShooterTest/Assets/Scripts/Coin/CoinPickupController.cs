
using UnityEngine;

public class CoinPickupController : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed;
    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime * Vector3.up);       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerView>() == null)
            return;
        EventService.Instance.InvokeCoinCollected();
    }
}
