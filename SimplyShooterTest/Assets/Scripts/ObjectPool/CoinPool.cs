

using UnityEngine;

public class CoinPool : PoolService<CoinPickupView>
{
    private CoinPickupView CoinPrefab;
    private Transform parent;

    public CoinPool(CoinPickupView coin, Transform parent)
    {
        CoinPrefab = coin;
        this.parent = parent;
    }
    protected override CoinPickupView CreateItem()
    {
        return GameObject.Instantiate(CoinPrefab,parent);
    }
    public override void ReturnItem(CoinPickupView item)
    {
        item.gameObject.SetActive(false);
        base.ReturnItem(item);
    }
}
