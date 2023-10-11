
using System.Collections;
using UnityEngine;

public abstract class ProjectileController : MonoBehaviour
{
    [SerializeField]
    private ProjectileScriptableObject projectileData;

    private new Rigidbody rigidbody;
    private Transform EnemyTransform = null;
    protected Coroutine AutoReturn;
    protected float NotCollidedWaitTime = 10f;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    public void SetEnemtTransform(Transform transform)
    {
        EnemyTransform = transform;
    }
    private void OnEnable()
    {
        AutoReturn = StartCoroutine(ReturnIfNotCollided());
    }
    public void Fly()
    {
        Vector3 direction = (EnemyTransform.position - transform.position).normalized;
        direction.y = 0;
        rigidbody.velocity =  projectileData.Speed * direction;
    }
    protected virtual void OnDisable()
    {
        rigidbody.velocity = Vector3.zero;
        StopCoroutine(AutoReturn);
    }

    protected abstract IEnumerator ReturnIfNotCollided();
    protected abstract void OnTriggerEnter(Collider other);
    protected abstract void DealDamage();
}
