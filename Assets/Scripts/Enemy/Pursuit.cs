using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Pursuit : MonoBehaviour
{
    [SerializeField] private float _speed = 1.5f;

    private Rigidbody2D _rigidbody2D;

    private Vector2 _target;

    private bool _isPursuiting = false;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_isPursuiting)
            Move();
    }

    public void StartPuruit(Vector2 playerPosition)
    {
        _isPursuiting = true;
        _target = playerPosition;
    }

    public void StopPursuit()
    {
        _isPursuiting = false;
    }

    private void Move()
    {
        Vector2 direction = (_target - (Vector2)transform.position).normalized;
        _rigidbody2D.velocity = new Vector2(direction.x * _speed, _rigidbody2D.velocity.y);
    }


}
