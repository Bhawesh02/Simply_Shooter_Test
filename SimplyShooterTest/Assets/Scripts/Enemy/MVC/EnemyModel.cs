

using System;

public class EnemyModel 
{
    public int Health;
    public float PetrolRadius;
    public float PetrolPointSwitchDelay;
    public float PetrolSpeed;
    public float ChaseRadius;
    public float ChaseSpeed;

    public EnemyModel(EnemyScriptableObject enemyScriptableObject)
    {
        SetData(enemyScriptableObject);
    }

    public void SetData(EnemyScriptableObject enemyScriptableObject)
    {
        Health = enemyScriptableObject.Health;
        PetrolRadius = enemyScriptableObject.PetrolRadius;
        PetrolPointSwitchDelay = enemyScriptableObject.PetrolPointSwitchDelay;
        PetrolSpeed = enemyScriptableObject.PetrolSpeed;
        ChaseRadius = enemyScriptableObject.ChaseRadius;
        ChaseSpeed = enemyScriptableObject.ChaseSpeed;
    }
}
