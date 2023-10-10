using UnityEngine;

public class BulletController : ProjectileController
{
    protected override void DealDamage()
    {
        Debug.Log("Deal Damage to enemy");
    }

    protected override void OnTriggerEnter(Collider other)
    {
        EnemyView enemy = other.GetComponent<EnemyView>();
        if (enemy!=null)
        {
            DealDamage();
        }
        ProjectileService.Instance.ReturnBullet(this);
    }
}
