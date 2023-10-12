
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController 
{
    private EnemyView enemyView;
    public EnemyModel EnemyModel { get;}

    private int walableAreaMask = 1;
    
    public Coroutine PlayerDetectionCorotine;

    public EnemyController(EnemyView enemyView,EnemyScriptableObject enemyScriptableObject)
    {
        this.enemyView = enemyView;
        EnemyModel = new(enemyScriptableObject);
        PlayerDetectionCorotine = enemyView.StartCoroutine(PlayerDetectStart());
    }

    


    public void RefreshData(EnemyScriptableObject enemyData)
    {
        if(enemyData == enemyView.EnemyScriptableObject)
        {
            EnemyModel.SetData(enemyData);
        }
    }

    public void ChangeState(EnemyStates newState)
    {
        if (newState == EnemyModel.CurrentEnemyState)
            return;
        EnemyModel.CurrentEnemyState?.OnStateExit();
        EnemyModel.CurrentEnemyState = newState;
        EnemyModel.CurrentEnemyState.OnStateEnter();
    }
    public void ChangeSpeed()
    {
        if (EnemyModel.CurrentEnemyState == enemyView.EnemyPetrolState)
            enemyView.NavMeshAgent.speed = EnemyModel.PetrolSpeed;
        else
            enemyView.NavMeshAgent.speed = EnemyModel.ChaseSpeed;
    }
    public void GoToRandomPointOnNavMesh()
    { 
        enemyView.NavMeshAgent.SetDestination(GetRandomPointOnNavMesh());
    }

    private Vector3 GetRandomPointOnNavMesh()
    {
        Vector3 randomPoint = enemyView.transform.position + Random.insideUnitSphere * EnemyModel.PetrolRadius;
        NavMesh.SamplePosition(randomPoint, out NavMeshHit hit, EnemyModel.PetrolRadius, walableAreaMask);
        return hit.position;
    }
    public IEnumerator PlayerDetectStart()
    {
        yield return new WaitForSeconds(EnemyModel.PlayerDetectionDelay);
        DetectPlayer();
        PlayerDetectionCorotine = enemyView.StartCoroutine(PlayerDetectStart());
    }

    private void DetectPlayer()
    {
        Collider[] playerCollider = Physics.OverlapSphere(enemyView.transform.position, EnemyModel.ChaseRadius, EnemyModel.PlayerLayerMask);
        if(playerCollider.Length == 0) 
        {
            EnemyModel.Player = null;
            ChangeState(enemyView.EnemyPetrolState);
            return;
        }
        EnemyModel.Player = playerCollider[0].gameObject.GetComponent<PlayerView>();
        ChangeState(enemyView.EnemyChaseState);
    }
    public void TakeDamage(EnemyView view, float damage)
    {
        if (view != enemyView)
            return;
        EnemyModel.CurrentHealth -= damage;
        UpodateHealthBarAmt();
        if(EnemyModel.CurrentHealth <= 0)
        {
            EnemyDead();
        }
    }

    private void UpodateHealthBarAmt()
    {
        enemyView.HealthBarForground.fillAmount = EnemyModel.CurrentHealth/EnemyModel.Health;
    }

    private void EnemyDead()
    {
        EventService.Instance.InokeEnemyDied(enemyView);
        GameObject.Destroy(enemyView.gameObject);
    }

    public void DrawGizmos()
    {    
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(enemyView.transform.position,EnemyModel.PetrolRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(enemyView.transform.position, EnemyModel.ChaseRadius);

    }

    public void PlayerLost()
    {
        EnemyModel.CurrentEnemyState?.OnStateExit();
        enemyView.StopAllCoroutines();
        enemyView.enabled = false;
    }
}
