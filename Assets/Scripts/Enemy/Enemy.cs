using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(DamageTaker))]
[RequireComponent(typeof(EnemyMovementController))]

public class Enemy : MonoBehaviour
{
    [field: SerializeField] public int Damage { get; private set; } = 15;

    private Health _health;
    private DamageTaker _damageTaker;
    private EnemyMovementController _enemyMovementController;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _damageTaker = GetComponent<DamageTaker>();
        _enemyMovementController = GetComponent<EnemyMovementController>();
    }

    private void OnEnable()
    {
        _health.Died += Die;
        _damageTaker.DamagedByPlayer += TakeDamage;
    }

    private void OnDisable()
    {
        _health.Died -= Die;
        _damageTaker.DamagedByPlayer -= TakeDamage;
    }

    private void FixedUpdate()
    {
        if (_enemyMovementController.IsPursuiting())
            _enemyMovementController.RefreshPlayerPosition();

        if (_enemyMovementController.IsPatroling())
            _enemyMovementController.CheckDistanceToCheckpoint();

        _enemyMovementController.Move();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }

    private void TakeDamage(int damage)
    {
        _health.TakeDamge(damage);
    }
}
