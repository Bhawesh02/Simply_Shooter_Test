
using UnityEngine;

public class ProjectileService : MonoGenericSingelton<ProjectileService>
{
    private BulletPool bulletPool;
    private MissilePool missilePool;
    [SerializeField]
    private BulletView bulletPrefab;
    [SerializeField]
    private MissileView missilePrefab;
    private void Start()
    {
        bulletPool = new(bulletPrefab,this);
        missilePool = new(missilePrefab,this);
    }

    public BulletView GetBullet()
    {
        return bulletPool.GetItem();
    }
    public void ReturnBullet(BulletView bullet)
    {
        bullet.gameObject.SetActive(false);
        bulletPool.ReturnItem(bullet);
    }

    public MissileView GetMissile()
    {
        return missilePool.GetItem();
    }
    public void ReturnMissile(MissileView missile)
    {
        missile.gameObject.SetActive(false);
        missilePool.ReturnItem(missile);
    }
}
