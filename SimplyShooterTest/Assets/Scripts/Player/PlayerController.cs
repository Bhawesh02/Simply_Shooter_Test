
using UnityEngine;

public class PlayerController
{
    private Vector2 movementAmount;
    private PlayerView playerView;
    public PlayerController(PlayerView view)
    {
        playerView = view;
    }
    
    public void SetMovementAmount(Vector2 movAmt)
    {
        movementAmount = movAmt;
    }

    public void MovePlayer()
    {
        Vector3 scaledMovement = playerView.NavMeshAgent.speed * Time.deltaTime * new Vector3(movementAmount.x,0,movementAmount.y);
        playerView.transform.LookAt(playerView.transform.position + scaledMovement,Vector3.up);
        playerView.NavMeshAgent.Move(scaledMovement);
    }
}
