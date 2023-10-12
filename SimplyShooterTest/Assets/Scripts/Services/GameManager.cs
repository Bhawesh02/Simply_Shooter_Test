
using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private List<EnemyView> EnemiesInScene = new();
    private void Awake()
    {
        EventService.Instance.EnemySpawned += AddEnemyInScene;
        EventService.Instance.EnemyDied += RemoveEnemyInScene;
        EventService.Instance.PlayerEnteredFishLine += HasPlayerWon;
    }


    private void OnDestroy()
    {
        EventService.Instance.EnemySpawned -= AddEnemyInScene;
        EventService.Instance.EnemyDied -= RemoveEnemyInScene;
        EventService.Instance.PlayerEnteredFishLine -= HasPlayerWon;
    }

    private void AddEnemyInScene(EnemyView enemyView)
    {
        EnemiesInScene.Add(enemyView);
    }

    private void RemoveEnemyInScene(EnemyView enemyView)
    {
        EnemiesInScene.Remove(enemyView);
    }

    private void HasPlayerWon()
    {
        if (EnemiesInScene.Count > 0)
            return;
        EventService.Instance.InvokePlayerWon();
    }
}
