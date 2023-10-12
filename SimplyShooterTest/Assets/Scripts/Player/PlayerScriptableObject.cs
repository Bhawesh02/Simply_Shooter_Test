
using UnityEngine;
[CreateAssetMenu(fileName ="NewPlayer",menuName ="ScriptableObject/NewPlayer")]
public class PlayerScriptableObject : ScriptableObject
{
    [field: SerializeField]
    public float EnemyDetectionDelay { get; private set; }
    [field: SerializeField]
    public float AutoAimRotationSpeed { get; private set; }
    [field: SerializeField]
    public int NumOfEnemiesToKillToChargeHype { get; private set; }
    [field: SerializeField]
    public float HypeModeDuration { get; private set; }
    [field: SerializeField]
    public float HypeModeFireRateMultiplier { get; private set; }
    
   /*private void OnValidate()
    {
        if (Application.isEditor)
            EventService.Instance.InvokePlayerDataChanged(this);
    }*/
}
