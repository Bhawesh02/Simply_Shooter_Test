

using System.Collections;
using UnityEngine;

public class EnemyChaseState : EnemyStates
{
    public override void OnStateEnter()
    {
        base.OnStateEnter();
        StartCoroutine(ChasePlayer());
    }
    private IEnumerator ChasePlayer()
    {
        EnemyView.NavMeshAgent.SetDestination(EnemyController.EnemyModel.Player.transform.position);
        yield return new WaitForSeconds(EnemyController.EnemyModel.PlayerPositionChangeDelay);
        StartCoroutine(ChasePlayer());

    }
    public override void OnStateExit()
    {
        StopAllCoroutines();
        base.OnStateExit();
    }
}