
using UnityEngine;


[CreateAssetMenu(fileName="NewWepon",menuName ="ScriptableObject/NewWeapon")]
public class WeaponScritableObject : ScriptableObject
{
    [field: SerializeField]
    public WeaponTypes WeaponType { get; private set; }
    [field: SerializeField]
    public float AttackRange { get; private set; }
    [field: SerializeField]
    public float FireRate { get; private set; }
    [field: SerializeField]
    public ProjectileType ProjectileType { get; private set; }
    [field: SerializeField]
    public float Damage { get; private set; }
}
