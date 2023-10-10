
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;


public class PlayerView : MonoBehaviour
{
    
    public NavMeshAgent NavMeshAgent;
    
    private PlayerController playerController;
    private void Awake()
    {
        playerController = new(this);
    }
    

    private void Update()
    {
        playerController.MovePlayer();
    }


}
