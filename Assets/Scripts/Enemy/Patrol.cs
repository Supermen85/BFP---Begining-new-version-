using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Patrol : MonoBehaviour
{
    [SerializeField] private Transform _checkpoint1;
    [SerializeField] private Transform _checkpoint2;

    [SerializeField] private float _speed = 1f;

    private Rigidbody2D _rigidbody2D;
    
    private Transform _currentCheckpoint;

    private bool _isPatroling = false;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();    

        SetRandomCheckpoint();
        _isPatroling = true;
    }

    private void FixedUpdate()
    {
        if (_isPatroling)
            Move();
    }

    public void StartPatrol()
    {
        SetFarestCheckpoint();
        _isPatroling = true;
    }

    public void StopPatrol()
    {
        _isPatroling = false;
    }

    private void Move()
    {
        Vector2 direction = (_currentCheckpoint.position - transform.position).normalized;
        _rigidbody2D.velocity = new Vector2(direction.x * _speed, _rigidbody2D.velocity.y);

        float minDistance = 0.2f;

        if ((_currentCheckpoint.position - transform.position).sqrMagnitude < minDistance * minDistance)
            SwitchCheckpoint();
    }

    private void SwitchCheckpoint()
    {
        _currentCheckpoint = _currentCheckpoint == _checkpoint1 ? _checkpoint2 : _checkpoint1;
    }

    private void SetRandomCheckpoint()
    {
        _currentCheckpoint = Random.Range(0, 2) == 0 ? _checkpoint1 : _checkpoint2;
    }

    private void SetFarestCheckpoint()
    {
        _currentCheckpoint = ((_checkpoint1.position - transform.position).sqrMagnitude > (_checkpoint2.position - transform.position).sqrMagnitude) ? _checkpoint1 : _checkpoint2;
    }
}
