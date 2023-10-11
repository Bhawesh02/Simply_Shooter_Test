using UnityEngine;

public class EnemyView : MonoBehaviour
{
    public EnemyController EnemyController;
    public EnemyScriptableObject EnemyScriptableObject;

    
    public EnemyStates StartState;

    private void Awake()
    {
        EnemyController = new(this, EnemyScriptableObject);
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
        EnemyController.DrawPetrolGizmos();
    }


}
