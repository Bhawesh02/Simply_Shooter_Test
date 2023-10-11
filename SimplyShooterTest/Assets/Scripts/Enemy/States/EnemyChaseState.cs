

using System.Collections;
using UnityEngine;

public class EnemyChaseState : EnemyStates
{
    private Coroutine playerChaseCoroutine;
    public override void OnStateEnter()
    {
        base.OnStateEnter();
        playerChaseCoroutine = StartCoroutine(ChasePlayer());
    }
    private IEnumerator ChasePlayer()
    {
        EnemyView.NavMeshAgent.SetDestination(EnemyController.EnemyModel.Player.transform.position);
        yield return new WaitForSeconds(EnemyController.EnemyModel.PlayerPositionChangeDelay);
        playerChaseCoroutine = StartCoroutine(ChasePlayer());

    }
    public override void OnStateExit()
    {
        StopCoroutine(playerChaseCoroutine);
        base.OnStateExit();
    }
}