using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(EnemyDamageTaker))]
[RequireComponent(typeof(EnemyMovementController))]

public class Enemy : MonoBehaviour, IAttackable
{
    [field: SerializeField] public float Damage { get; private set; } = 15;

    public Vector3 Position => transform.position;

    
    private Health _health;
    private EnemyDamageTaker _enemyDamageTaker;
    private EnemyMovementController _enemyMovementController;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _enemyDamageTaker = GetComponent<EnemyDamageTaker>();
        _enemyMovementController = GetComponent<EnemyMovementController>();
    }

    private void OnEnable()
    {
        _health.Died += Die;
        _enemyDamageTaker.Damaged += TakeDamage;
    }

    private void OnDisable()
    {
        _health.Died -= Die;
        _enemyDamageTaker.Damaged -= TakeDamage;
    }

    private void FixedUpdate()
    {
        if (_enemyMovementController.IsPursuiting())
            _enemyMovementController.RefreshPlayerPosition();

        if (_enemyMovementController.IsPatroling())
            _enemyMovementController.CheckDistanceToCheckpoint();

        _enemyMovementController.Move();
    }

    public void TakeDamage(float damage)
    {
        _health.TakeDamge(damage);
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
