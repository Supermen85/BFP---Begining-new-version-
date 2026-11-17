using UnityEngine;

[RequireComponent(typeof(DamageTaker))]
[RequireComponent(typeof(EnemyMovementController))]

public class Enemy : MonoBehaviour
{
    [field: SerializeField] public float Damage { get; private set; } = 15;

    private Health _health;
    private DamageTaker _damageTaker;
    private EnemyMovementController _enemyMovementController;

    private void Awake()
    {
        _health = GetComponentInChildren<Health>();
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

    public void TakeDamage(float damage)
    {
        _health.TakeDamge(damage);
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
