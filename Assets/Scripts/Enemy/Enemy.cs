using UnityEngine;

[RequireComponent(typeof(Patrol))]
[RequireComponent(typeof(Pursuit))]
[RequireComponent(typeof(EnemyHealth))]

public class Enemy : MonoBehaviour
{
    [field: SerializeField] public int Damage { get; private set; } = 1;

    [SerializeField] private PlayerDetector _playerDetector;

    private Patrol _patrol;
    private Pursuit _pursuit;

    private void Awake()
    {
        _patrol = GetComponent<Patrol>();
        _pursuit = GetComponent<Pursuit>();
    }

    private void OnEnable()
    {
        _playerDetector.PlayerEntered += StartPursuit;
        _playerDetector.PlayerExited += StopPursuit;
    }

    private void OnDisable()
    {
        _playerDetector.PlayerEntered -= StartPursuit;
        _playerDetector.PlayerExited -= StopPursuit;
    }

    private void StartPursuit(Vector2 playerPosition)
    {
        _patrol.StopPatrol();
        _pursuit.StartPuruit(playerPosition);
    }

    private void StopPursuit()
    {
        _pursuit.StopPursuit();
        _patrol.StartPatrol();
    }
}
