using UnityEngine;

[RequireComponent(typeof(DistanceChecker))]

public class Patrol : MonoBehaviour
{
    [field: SerializeField] public float Speed { get; private set; } = 1f;

    [SerializeField] private Transform[] _checkpoints;

    public bool IsPatroling { get; private set; } = true;
    
    private Transform _currentCheckpoint;
    private DistanceChecker _distanceChecker;

    private void Awake()
    {
        _distanceChecker = GetComponent<DistanceChecker>();
        SetRandomCheckpoint();
    }

    public void StartPatrol()
    {
        SetFarestCheckpoint();
        IsPatroling = true;
    }

    public void StopPatrol()
    {
        IsPatroling = false;
    }

    public void CheckDistanceToCheckpoint(out Vector2 newCheckpoint)
    {
        newCheckpoint = Vector2.zero;

        if (_distanceChecker.IsCloseEnough(_currentCheckpoint.position))
        {
            SwitchCheckpoint();
            newCheckpoint = _currentCheckpoint.position;
        }
    }

    public Vector2 GetCheckpoint()
    {
        return _currentCheckpoint.position;
    }

    public void SetFarestCheckpoint()
    {
        float distance = 0;

        foreach (Transform checkpoint in _checkpoints)
        {
            float distanceToCheckpoint = (checkpoint.position - transform.position).sqrMagnitude;
            
            if (distanceToCheckpoint > distance)
            {
                distance = distanceToCheckpoint; ;
                _currentCheckpoint = checkpoint;
            }
        }
    }

    private void SwitchCheckpoint()
    {
        Transform previousCheckpoint = _currentCheckpoint;

        while (previousCheckpoint == _currentCheckpoint)
            SetRandomCheckpoint();
    }

    private void SetRandomCheckpoint()
    {
        _currentCheckpoint = _checkpoints[Random.Range(0, _checkpoints.Length)];
    }
}
