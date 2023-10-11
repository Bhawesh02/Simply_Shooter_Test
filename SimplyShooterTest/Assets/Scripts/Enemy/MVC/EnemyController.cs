
using System.Collections;
using Unity.VisualScripting;
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
        EventService.Instance.EnemyDataChanged += RefreshData;
        PlayerDetectionCorotine = enemyView.StartCoroutine(PlayerDetectStart());
    }
    ~EnemyController()
    {
        EventService.Instance.EnemyDataChanged -= RefreshData;
    }

    
    private void RefreshData(EnemyScriptableObject enemyData)
    {
        if(enemyData == enemyView.EnemyScriptableObject)
        {
            EnemyModel.SetData(enemyData);
        }
    }

    public void ChangeState(EnemyStates newState)
    {
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

    public void DrawGizmos()
    {    
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(enemyView.transform.position,EnemyModel.PetrolRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(enemyView.transform.position, EnemyModel.ChaseRadius);

    }

}
