
using UnityEngine;

[RequireComponent(typeof(EnemyView))]
public class EnemyStates : MonoBehaviour
{
    protected EnemyView EnemyView;
    protected EnemyController EnemyController;

    protected virtual void Awake()
    {
        EnemyView = GetComponent<EnemyView>();
    }
    protected virtual void Start()
    {
        EnemyController = EnemyView.EnemyController;
    }

    public virtual void OnStateEnter()
    {
        this.enabled = true;
    }
    public virtual void OnStateExit()
    {
        this.enabled = false;
    }


}