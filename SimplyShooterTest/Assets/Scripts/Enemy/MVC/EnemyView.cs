using UnityEngine;

public class EnemyView : MonoBehaviour
{
    public EnemyController enemyController;
    public EnemyScriptableObject enemyScriptableObject;
    private void Awake()
    {
        enemyController = new(this, enemyScriptableObject);
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying)
        {
            return;
        }
        enemyController.DrawPetrolGizmos();
    }
}
