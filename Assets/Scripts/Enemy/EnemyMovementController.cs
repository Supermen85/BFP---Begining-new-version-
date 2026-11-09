using UnityEngine;

[RequireComponent(typeof(Patrol))]
[RequireComponent(typeof(Pursuit))]
[RequireComponent(typeof(EnemyMover))]

public class EnemyMovementController : MonoBehaviour
{
    [SerializeField] private PlayerDetector _playerDetector;

    private Patrol _patrol;
    private Pursuit _pursuit;
    private EnemyMover _enemyMover;

    private Vector2 _target;
    private Transform _playerTransform;

    private void Awake()
    {
        _patrol = GetComponent<Patrol>();
        _pursuit = GetComponent<Pursuit>();
        _enemyMover = GetComponent<EnemyMover>();
    }

    private void Start()
    {
        _enemyMover.SetSpeed(_patrol.Speed);
        _target = _patrol.GetCheckpoint();
    }

    private void OnEnable()
    {
        _playerDetector.PlayerEntered += StartPursuit;
        _playerDetector.PlayerExited += StartPatrol;
    }

    private void OnDisable()
    {
        _playerDetector.PlayerEntered -= StartPursuit;
        _playerDetector.PlayerExited -= StartPatrol;
    }

    public void Move()
    {
        _enemyMover.Move(_target);
    }

    public bool IsPatroling()
    {
        return _patrol.IsPatroling;
    }

    public void CheckDistanceToCheckpoint()
    {
        _patrol.CheckDistanceToCheckpoint(out Vector2 newTarget);

        if (newTarget != Vector2.zero)
            _target = newTarget;
    }

    public void RefreshPlayerPosition()
    {
        _target = _playerTransform.position;
    }

    public bool IsPursuiting()
    {
        return _pursuit.IsPursuiting;
    }

    private void StartPursuit(Transform playerTransform)
    {
        _patrol.StopPatrol();
        _pursuit.StartPursuit();
        _enemyMover.SetSpeed(_pursuit.Speed);
        _playerTransform = playerTransform;
        _target = playerTransform.position;
    }

    private void StartPatrol()
    {
        _pursuit.StopPursuit();
        _patrol.StartPatrol();
        _enemyMover.SetSpeed(_patrol.Speed);
        _target = _patrol.GetCheckpoint();
    }
}
