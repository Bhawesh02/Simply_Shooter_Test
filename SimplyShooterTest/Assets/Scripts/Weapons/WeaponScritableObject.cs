
using UnityEngine;


[CreateAssetMenu(fileName="NewWepon",menuName ="ScriptableObject/NewWeapon")]
public class WeaponScritableObject : ScriptableObject
{
    public WeaponTypes WeaponType;
    public float AttackRange;
    public float FireRate;
    public ProjectileType ProjectileType;
}
