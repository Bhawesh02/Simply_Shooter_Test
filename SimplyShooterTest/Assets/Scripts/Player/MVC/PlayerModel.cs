

using System.Collections.Generic;
using UnityEngine;

public class PlayerModel 
{
    public List<EnemyView> Enemies;
    public EnemyView NearestEnemy;
    public WeaponScritableObject CurrentWeapon;
    public GameObject CurrentWeaponContainer;
    public float CurrentFireRate;
    public float EnemyDetectionDelay = 0.1f;
    public float AutoAimRotationSpeed;
    public int NumOfCoinsColleted ;
    public int NumOfEnemiesToKillToChargeHype;
    public int NumberOfEnemiesKilledSinceLastHypeCharge;
    public bool InHypeMode;
    public float HypeModeDuration;
    public float HypeModeFireRateMultiplier;
    public PlayerModel(PlayerScriptableObject playerData)
    {
        SetPlayerData(playerData);
        NumOfCoinsColleted = 0;
        Enemies = new();
        NumberOfEnemiesKilledSinceLastHypeCharge = 0;
        InHypeMode = false;
        CurrentFireRate = 0f;
    }
    public void SetPlayerData(PlayerScriptableObject playerData)
    {
        AutoAimRotationSpeed = playerData.AutoAimRotationSpeed;
        NumOfEnemiesToKillToChargeHype = playerData.NumOfEnemiesToKillToChargeHype;
        HypeModeDuration = playerData.HypeModeDuration;
        HypeModeFireRateMultiplier = playerData.HypeModeFireRateMultiplier;

    }
}
