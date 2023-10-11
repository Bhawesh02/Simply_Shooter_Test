

using System.Collections;
using UnityEngine;

public class EnemyPetrolState : EnemyStates
{
    private Coroutine petrolCoroutine;
    public override void OnStateEnter()
    {
        base.OnStateEnter();
        petrolCoroutine = StartCoroutine(GoToRandomPoint());
    }
    private IEnumerator GoToRandomPoint()
    {
        yield return new WaitForSeconds(EnemyController.EnemyModel.PetrolPointSwitchDelay);
        EnemyController.GoToRandomPointOnNavMesh();
        petrolCoroutine = StartCoroutine(GoToRandomPoint());
    }
    public override void OnStateExit()
    {
        if (petrolCoroutine != null)
        {
            StopCoroutine(petrolCoroutine);
        }
        base.OnStateExit();
    }
}
