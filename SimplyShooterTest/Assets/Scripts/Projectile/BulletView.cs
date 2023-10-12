using System.Collections;
using UnityEngine;

public class BulletView : ProjectileView
{
    [SerializeField]
    private TrailRenderer trailRenderer;
    private EnemyView enemy;

    protected override void OnDisable()
    {
        base.OnDisable();
        trailRenderer.Clear();
    }
    protected override void DealDamage()
    {
        EventService.Instance.InvokeEnemyDamaged(enemy, Damage);
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ProjectileView>() != null || other.gameObject.CompareTag("FinishArea") || other.transform.root.GetComponent<PlayerView>() != null)
        {
            return;
        }
        enemy = other.GetComponent<EnemyView>();
        if (enemy != null)
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
