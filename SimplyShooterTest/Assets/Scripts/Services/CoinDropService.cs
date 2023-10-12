
using System;
using UnityEngine;

public class CoinDropService : MonoGenericSingelton<CoinDropService>
{
    [SerializeField]
    private CoinPickupView coinPrefab;

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
    private void SpawnCoin(EnemyView enemy)
    {
        CoinPickupView coin = coinPool.GetItem();
        coin.transform.position = new(enemy.transform.position.x, coin.transform.position.y, enemy.transform.position.z);
        coin.gameObject.SetActive(true);
    }
    private void RemoveCoin(CoinPickupView coin)
    {
        coinPool.ReturnItem(coin);
    }

}
