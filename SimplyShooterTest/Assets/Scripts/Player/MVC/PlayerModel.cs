

using System.Collections.Generic;
using UnityEngine;

public class PlayerModel 
{
    public List<EnemyView> Enemies;
    public EnemyView NearestEnemy;
    public WeaponScritableObject CurrentWeapon;
    public GameObject CurrentWeaponContainer;
    public float EnemyDetectionDelay = 0.1f;
    public float AutoAimRotationSpeed;
    public int NumOfCoinsColleted ;
    public PlayerModel()
    {
        NumOfCoinsColleted = 0;
        AutoAimRotationSpeed = 200f;
        Enemies = new();
    }
}
