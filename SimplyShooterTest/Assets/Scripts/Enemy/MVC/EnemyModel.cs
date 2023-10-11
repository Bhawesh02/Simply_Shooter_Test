

using System;
using UnityEngine;

public class EnemyModel 
{
    public float Health;
    public float CurrentHealth;
    public float PetrolRadius;
    public float PetrolPointSwitchDelay;
    public float PetrolSpeed;
    public float ChaseRadius;
    public float ChaseSpeed;
    public float PlayerDetectionDelay;
    public float PlayerPositionChangeDelay;
    public LayerMask PlayerLayerMask;
    public EnemyStates CurrentEnemyState;
    public PlayerView Player;
    public EnemyModel(EnemyScriptableObject enemyScriptableObject)
    {
        SetData(enemyScriptableObject);
    }

    public void SetData(EnemyScriptableObject enemyScriptableObject)
    {
        CurrentHealth = Health = enemyScriptableObject.Health;
        PetrolRadius = enemyScriptableObject.PetrolRadius;
        PetrolPointSwitchDelay = enemyScriptableObject.PetrolPointSwitchDelay;
        PetrolSpeed = enemyScriptableObject.PetrolSpeed;
        ChaseRadius = enemyScriptableObject.ChaseRadius;
        ChaseSpeed = enemyScriptableObject.ChaseSpeed;
        PlayerDetectionDelay = enemyScriptableObject.PlayerDetectionDelay;
        PlayerPositionChangeDelay = enemyScriptableObject.PlayerPositionChangeDelay;
        PlayerLayerMask = enemyScriptableObject.PlayerLayerMask;
    }
}
