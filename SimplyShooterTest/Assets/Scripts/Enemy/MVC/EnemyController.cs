
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
        if(enemyData == enemyView.enemyScriptableObject)
        {
            enemyModel.SetData(enemyData);
        }
    }

    public void DrawPetrolGizmos()
    {
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(enemyView.transform.position,enemyModel.PetrolRadius);
    }

}
