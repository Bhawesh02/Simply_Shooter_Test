using System.Collections;
using UnityEngine;

public class MissileController : ProjectileController
{
    protected override void DealDamage()
    {
        Debug.Log("Blast");
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ProjectileController>() != null)
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
