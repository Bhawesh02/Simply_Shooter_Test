
using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
[RequireComponent(typeof(NavMeshAgent),typeof(EnemyChaseState),typeof(EnemyPetrolState))]
public class EnemyView : MonoBehaviour
{
    public EnemyController EnemyController { get;private set; }
    public EnemyScriptableObject EnemyScriptableObject;
    public EnemyChaseState EnemyChaseState { get; private set; }
    public EnemyPetrolState EnemyPetrolState { get; private set; }
    public NavMeshAgent NavMeshAgent { get; private set; }
    public EnemyStates StartState;
    public Canvas HealthBarCanvas;
    public Image HealthBarForground;
    public Camera MainCamera;
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
        EventService.Instance.PlayerLost += EnemyController.PlayerLost;
    }


    private void OnDestroy()
    {
        EventService.Instance.PlayerLost -= EnemyController.PlayerLost;
    }
    private void Update()
    {
        HealthBarCanvas.transform.rotation = Quaternion.LookRotation(HealthBarForground.transform.position - MainCamera.transform.position);
    }
    private void OnDrawGizmos()
    {
        if (!Application.isPlaying)
        {
            return;
        }
        EnemyController.DrawGizmos();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.root.GetComponent<PlayerView>()!=null)
        {
            EventService.Instance.InvokePlayerLost() ;
        }
    }
}
