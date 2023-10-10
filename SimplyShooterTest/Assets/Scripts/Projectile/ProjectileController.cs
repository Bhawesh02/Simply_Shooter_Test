
using UnityEngine;

public abstract class ProjectileController : MonoBehaviour
{
    [SerializeField]
    private ProjectileScriptableObject projectileData;

    private new Rigidbody rigidbody;
    private Transform EnemyTransform = null;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    public void SetEnemtTransform(Transform transform)
    {
        EnemyTransform = transform;
    }
    public void Fly()
    {
        Vector3 direction = (EnemyTransform.position - transform.position).normalized;
        direction.y = 0;
        rigidbody.velocity =  projectileData.Speed * direction;
    }
    private void OnDisable()
    {
        rigidbody.velocity = Vector3.zero;
    }
    protected abstract void OnTriggerEnter(Collider other);
    protected abstract void DealDamage();
}
