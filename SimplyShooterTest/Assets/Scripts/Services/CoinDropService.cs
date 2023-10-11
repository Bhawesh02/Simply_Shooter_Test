
using System;
using UnityEngine;

public class CoinDropService : MonoGenericSingelton<CoinDropService>
{
    [SerializeField]
    private CoinPickupController coinPrefab;

    private CoinPool coinPool;
    private void Start()
    {
        coinPool = new(coinPrefab, transform);
        EventService.Instance.EnemyDied += SpawnCoin;
        EventService.Instance.CoinCollected += RemoveCoin;
    }

    

    private void OnDestroy()
    {
        EventService.Instance.EnemyDied -= SpawnCoin;
    }
    private void SpawnCoin(Transform enemyTransform)
    {
        CoinPickupController coin = coinPool.GetItem();
        coin.transform.position = new(enemyTransform.position.x, coin.transform.position.y, enemyTransform.position.z);
        coin.gameObject.SetActive(true);
    }
    private void RemoveCoin(CoinPickupController coin)
    {
        coinPool.ReturnItem(coin);
    }

}
