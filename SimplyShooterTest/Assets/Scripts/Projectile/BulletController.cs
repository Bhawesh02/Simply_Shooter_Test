using System.Collections;
using UnityEngine;

public class BulletController : ProjectileController
{
    [SerializeField]
    private TrailRenderer trailRenderer;

    protected override void OnDisable()
    {
        base.OnDisable();
        trailRenderer.Clear();
    }
    protected override void DealDamage()
    {
        Debug.Log("Deal Damage to enemy");
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<ProjectileController>() != null) {
            return;
        }
        EnemyView enemy = other.GetComponent<EnemyView>();
        if (enemy!=null)
        {
            DealDamage();
        }
        ProjectileService.Instance.ReturnBullet(this);
    }

    protected override IEnumerator ReturnIfNotCollided()
    {
        yield return new WaitForSeconds(NotCollidedWaitTime);
        ProjectileService.Instance.ReturnBullet(this);
    }
}
