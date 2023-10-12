
using UnityEngine;

public class MissilePool : PoolService<MissileView>
{
    private MissileView missileController;
    private ProjectileService parent;
    public MissilePool(MissileView missileController,ProjectileService bulletPoolService)
    {
        this.missileController = missileController;
        parent = bulletPoolService;
    }
    protected override MissileView CreateItem()
    {
        return GameObject.Instantiate(missileController,parent.transform);
    }
}
