
using UnityEngine;

public class MissilePool : PoolService<MissileController>
{
    private MissileController missileController;
    private ProjectileService parent;
    public MissilePool(MissileController missileController,ProjectileService bulletPoolService)
    {
        this.missileController = missileController;
        parent = bulletPoolService;
    }
    protected override MissileController CreateItem()
    {
        return GameObject.Instantiate(missileController,parent.transform);
    }
}
