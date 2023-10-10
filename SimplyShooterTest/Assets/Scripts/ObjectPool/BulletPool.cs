
using UnityEngine;

public class BulletPool : PoolService<BulletController>
{
    private BulletController bulletController;
    private ProjectileService parent;
    public BulletPool(BulletController bulletController,ProjectileService bulletPoolService)
    {
        this.bulletController = bulletController;
        parent = bulletPoolService;
    }
    protected override BulletController CreateItem()
    {
        return GameObject.Instantiate(bulletController,parent.transform);
    }
}
