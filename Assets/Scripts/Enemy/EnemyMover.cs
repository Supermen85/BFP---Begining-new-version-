using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class EnemyMover : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    
    private float _speed;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 target)
    {
        Vector2 direction = (target - (Vector2)transform.position).normalized;
        _rigidbody2D.velocity = new Vector2(direction.x * _speed, _rigidbody2D.velocity.y);
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }
}
