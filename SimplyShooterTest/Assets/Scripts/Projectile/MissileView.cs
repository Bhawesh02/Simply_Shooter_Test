using System.Collections;
using UnityEngine;

public class MissileView : ProjectileView
{
    [SerializeField]
    private LayerMask enemyLayerMask;
    protected override void DealDamage()
    {
        Collider[] hitCollider = Physics.OverlapSphere(transform.position,projectileData.AoeRange, enemyLayerMask);
        EnemyView enemy;
        for(int i = 0; i < hitCollider.Length; i++)
        {
            enemy = hitCollider[i].gameObject.GetComponent<EnemyView>();
            EventService.Instance.InvokeEnemyDamaged(enemy, Damage);
        }
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ProjectileView>() != null)
        {
            return;
        }
        DealDamage();
        ProjectileService.Instance.ReturnMissile(this);
    }

    protected override IEnumerator ReturnIfNotCollided()
    {
        yield return new WaitForSeconds(NotCollidedWaitTime);
        ProjectileService.Instance.ReturnMissile(this);
    }
}
