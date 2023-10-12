
using UnityEngine;

public class CoinPickupController : PickupController
{
    [SerializeField]
    private float rotationSpeed;
    
    
    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime * Vector3.up);       
    }
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (player == null)
            return;
        EventService.Instance.InvokeCoinCollected(this);

    }
}
