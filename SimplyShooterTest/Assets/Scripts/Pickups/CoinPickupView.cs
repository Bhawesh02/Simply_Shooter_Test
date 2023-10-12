
using UnityEngine;

public class CoinPickupView : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed;
    
    
    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime * Vector3.up);       
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerView player = other.GetComponent<PlayerView>();
        if (player == null)
            return;
        EventService.Instance.InvokeCoinCollected(this);

    }
}
