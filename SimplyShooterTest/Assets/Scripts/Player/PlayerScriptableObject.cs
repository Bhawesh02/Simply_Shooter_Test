
using UnityEngine;
[CreateAssetMenu(fileName ="NewPlayer",menuName ="ScriptableObject/NewPlayer")]
public class PlayerScriptableObject : ScriptableObject
{
    public float EnemyDetectionDelay;
    public float AutoAimRotationSpeed;
    public int NumOfEnemiesToKillToChargeHype;
    public float HypeModeDuration;
    public float HypeModeFireRateMultiplier;
    private void OnValidate()
    {
        EventService.Instance.InvokePlayerDataChanged(this);
    }
}
