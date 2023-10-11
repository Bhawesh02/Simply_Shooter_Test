

using UnityEngine;

public class CoinPool : PoolService<CoinPickupController>
{
    private CoinPickupController CoinPrefab;
    private Transform parent;

    public CoinPool(CoinPickupController coin, Transform parent)
    {
        CoinPrefab = coin;
        this.parent = parent;
    }
    protected override CoinPickupController CreateItem()
    {
        return GameObject.Instantiate(CoinPrefab,parent);
    }
    public override void ReturnItem(CoinPickupController item)
    {
        item.gameObject.SetActive(false);
        base.ReturnItem(item);
    }
}
