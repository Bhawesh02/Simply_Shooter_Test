
using UnityEngine;

[CreateAssetMenu(fileName ="NewEnemy",menuName ="ScriptableObject/NewEnemy")]
public class EnemyScriptableObject : ScriptableObject
{
    [field:SerializeField]
    public float Health { get; private set; }
    [field: SerializeField]
    public float PetrolRadius { get; private set; }
    [field: SerializeField]
    public float PetrolPointSwitchDelay { get; private set; }
    [field: SerializeField]
    public float PetrolSpeed { get; private set; }
    [field: SerializeField]
    public float ChaseRadius { get; private set; }
    [field: SerializeField]
    public float ChaseSpeed { get; private set; }
    [field: SerializeField]
    public float PlayerDetectionDelay { get; private set; }
    [field: SerializeField]
    public float PlayerPositionChangeDelay { get; private set; }
    [field: SerializeField]
    public LayerMask PlayerLayerMask { get; private set; }

    /*private void OnValidate()
    {  
        if(Application.isEditor)
        EventService.Instance.InvokeEnemyDataChanged(this);
    }*/
}

