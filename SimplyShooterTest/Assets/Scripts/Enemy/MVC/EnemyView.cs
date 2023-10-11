using System.Collections;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent),typeof(EnemyChaseState),typeof(EnemyPetrolState))]
public class EnemyView : MonoBehaviour
{
    public EnemyController EnemyController { get;private set; }
    public EnemyScriptableObject EnemyScriptableObject;
    public EnemyChaseState EnemyChaseState { get; private set; }
    public EnemyPetrolState EnemyPetrolState { get; private set; }
    public NavMeshAgent NavMeshAgent { get; private set; }
    public EnemyStates StartState;

    private void Awake()
    {
        EnemyController = new(this, EnemyScriptableObject);
        NavMeshAgent = GetComponent<NavMeshAgent>();
        EnemyPetrolState = GetComponent<EnemyPetrolState>();
        EnemyChaseState = GetComponent<EnemyChaseState>();
    }

    private void Start()
    {
        EnemyController.ChangeState(StartState);
    }
    
    private void OnDrawGizmos()
    {
        if (!Application.isPlaying)
        {
            return;
        }
        EnemyController.DrawGizmos();
    }


}
