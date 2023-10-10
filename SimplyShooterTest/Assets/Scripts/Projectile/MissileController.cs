using UnityEngine;

public class MissileController : ProjectileController
{
    protected override void DealDamage()
    {
        Debug.Log("Blast");
    }

    protected override void OnTriggerEnter(Collider other)
    {
        DealDamage();
    }
}
