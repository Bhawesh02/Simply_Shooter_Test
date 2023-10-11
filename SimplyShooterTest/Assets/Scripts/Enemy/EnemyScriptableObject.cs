
using UnityEngine;

[CreateAssetMenu(fileName ="NewEnemy",menuName ="ScriptableObject/NewEnemy")]
public class EnemyScriptableObject : ScriptableObject
{
    public int Health;
    public float PetrolRadius;
    public float PetrolPointSwitchDelay;
    public float PetrolSpeed;
    public float ChaseRadius;
    public float ChaseSpeed;
    public float PlayerDetectionDelay;
    public float PlayerPositionChangeDelay;
    public LayerMask PlayerLayerMask;

    private void OnValidate()
    {
        EventService.Instance.InvokeEnemyDataChanged(this);
    }
}

