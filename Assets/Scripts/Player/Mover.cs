using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private int _speed = 2;
    [SerializeField] private int _knockbackForce = 15;

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Knockback(Vector2 enemyPosition)
    {
        Vector2 knockbackDirection = (Vector2)transform.position - enemyPosition;

        _rigidbody2D.AddForce(knockbackDirection.normalized * _knockbackForce, ForceMode2D.Impulse);
    }

    public void Run(Vector2 direction)
    {
        if (direction == Vector2.left)
            _rigidbody2D.velocity = new Vector2(-1 * _speed, _rigidbody2D.velocity.y);

        if (direction == Vector2.right)
            _rigidbody2D.velocity = new Vector2(_speed, _rigidbody2D.velocity.y);
    }
}
