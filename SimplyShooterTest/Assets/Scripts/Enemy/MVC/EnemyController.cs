
using System;
using UnityEngine;

public class EnemyController 
{
    private EnemyView enemyView;
    private EnemyModel enemyModel;
    public EnemyController(EnemyView enemyView,EnemyScriptableObject enemyScriptableObject)
    {
        this.enemyView = enemyView;
        enemyModel = new(enemyScriptableObject);
        EventService.Instance.EnemyDataChanged += RefreshData;
    }
    ~EnemyController()
    {
        EventService.Instance.EnemyDataChanged -= RefreshData;
    }

    
    private void RefreshData(EnemyScriptableObject enemyData)
    {
        if(enemyData == enemyView.EnemyScriptableObject)
        {
            enemyModel.SetData(enemyData);
        }
    }

    public void ChangeState(EnemyStates newState)
    {
        enemyModel.CurrentEnemyState?.OnStateExit();
        enemyModel.CurrentEnemyState = newState;
        enemyModel.CurrentEnemyState.OnStateEnter();
    }
    public void DrawPetrolGizmos()
    {
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(enemyView.transform.position,enemyModel.PetrolRadius);
    }

}
