

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
    public PlayerModel()
    {
        NumOfCoinsColleted = 0;
        AutoAimRotationSpeed = 200f;
        Enemies = new();
        NumOfEnemiesToKillToChargeHype = 3;
        NumberOfEnemiesKilledSinceLastHypeCharge = 0;
        InHypeMode = false;
        HypeModeDuration = 3f;
        HypeModeFireRateMultiplier = 5f;
        CurrentFireRate = 0f;
    }
}
