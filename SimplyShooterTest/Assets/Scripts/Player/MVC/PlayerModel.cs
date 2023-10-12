

using UnityEngine;

public class PlayerModel 
{
    public EnemyView Enemy;
    public WeaponScritableObject CurrentWeapon;
    public GameObject CurrentWeaponContainer;
    public float EnemyDetectionDelay = 0.1f;
    public int NumOfCoinsColleted ;
    public PlayerModel()
    {
        NumOfCoinsColleted = 0;
    }
}
