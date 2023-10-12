
using UnityEngine;

public class BulletPool : PoolService<BulletView>
{
    private BulletView bulletController;
    private ProjectileService parent;
    public BulletPool(BulletView bulletController,ProjectileService bulletPoolService)
    {
        this.bulletController = bulletController;
        parent = bulletPoolService;
    }
    protected override BulletView CreateItem()
    {
        return GameObject.Instantiate(bulletController,parent.transform);
    }
}
