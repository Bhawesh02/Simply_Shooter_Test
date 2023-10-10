
using System;
using System.Collections;
using UnityEngine;

public class PlayerController
{
    private Vector2 movementAmount;
    private PlayerView playerView;
    private PlayerModel playerModel;
    public PlayerController(PlayerView view)
    {
        playerView = view;
        playerModel = new();
    }

    public void SetMovementAmount(Vector2 movAmt)
    {
        movementAmount = movAmt;
    }

    public void MovePlayer()
    {
        if (movementAmount == Vector2.zero)
            return;
        Vector3 scaledMovement = playerView.NavMeshAgent.speed * Time.deltaTime * new Vector3(movementAmount.x, 0, movementAmount.y);
        if (playerModel.Enemy == null)
            playerView.transform.LookAt(playerView.transform.position + scaledMovement, Vector3.up);
        playerView.NavMeshAgent.Move(scaledMovement);
    }

    public void DetectEnemy()
    {
        Collider[] enemyColliders = Physics.OverlapSphere(playerView.transform.position, playerView.AttackRange, playerView.EnemyLayer);
        if (enemyColliders.Length == 0)
        {
            playerModel.Enemy = null;
            return;
        }
        playerModel.Enemy = enemyColliders[0].GetComponentInParent<EnemyView>();
        AimAtEnemy();

    }

    private void AimAtEnemy()
    {
        Vector3 distanceBetweenEnemyAndPlayer = playerModel.Enemy.transform.position - playerView.transform.position;
        float rotationY = Mathf.Atan2(distanceBetweenEnemyAndPlayer.x, distanceBetweenEnemyAndPlayer.z) * Mathf.Rad2Deg;
        playerView.transform.rotation = Quaternion.Euler(0.0f, rotationY, 0.0f);
    }
}
