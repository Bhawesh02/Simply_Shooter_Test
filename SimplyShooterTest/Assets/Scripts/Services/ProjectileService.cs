
using UnityEngine;

public class ProjectileService : MonoGenericSingelton<ProjectileService>
{
    private BulletPool bulletPool;
    private MissilePool missilePool;
    [SerializeField]
    private BulletController bulletPrefab;
    [SerializeField]
    private MissileController missilePrefab;
    private void Start()
    {
        bulletPool = new(bulletPrefab,this);
        missilePool = new(missilePrefab,this);
    }

    public BulletController GetBullet()
    {
        return bulletPool.GetItem();
    }
    public void ReturnBullet(BulletController bullet)
    {
        bullet.gameObject.SetActive(false);
        bulletPool.ReturnItem(bullet);
    }

    public MissileController GetMissile()
    {
        return missilePool.GetItem();
    }
    public void ReturnMissile(MissileController missile)
    {
        missile.gameObject.SetActive(false);
        missilePool.ReturnItem(missile);
    }
}
