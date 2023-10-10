

using UnityEngine;

public class PlayerModel 
{
    public EnemyView Enemy;
    public float AttackRange;
    public float FireRate;
    public WeaponTypes CurrentWeapon;
    public GameObject CurrentWeaponContainer;
    public float EnemyDetectionDelay = 0.1f;
}
