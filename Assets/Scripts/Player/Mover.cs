using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private int _jumpForce = 8;
    [SerializeField] private int _speed = 2;
    [SerializeField] private int _knockbackForce = 15;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    private Vector2 _direction = Vector2.zero;

    private bool _isRunningLeft = false;
    private bool _isRunningRight = false;

    private void Awake()
    {
        _rigidbody2D = GetComponentInParent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>() ;
    }

    private void FixedUpdate()
    {
        Run();
    }

    public void Knockback(Vector2 enemyPosition)
    {
        Vector2 knockbackDirection = (Vector2)transform.position - enemyPosition;

        _rigidbody2D.AddForce(knockbackDirection.normalized * _knockbackForce, ForceMode2D.Impulse);
    }

    public void Jump()
    {
        _animator.SetBool("isJumping", true);
        _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    public void Land()
    {
        _animator.SetBool("isJumping", false);
    }

    public void RunLeft(bool isRunningStarts)
    {
        _isRunningLeft = isRunningStarts;
        
        if (isRunningStarts)
        {
            if (_isRunningRight)
            {
                _direction = Vector2.zero;
            }
            else
            {
                _direction = Vector2.left;
            }
        }
        else
        {
            if (_isRunningRight)
            {
                _direction = Vector2.right;
            }
            else
            {
                _direction = Vector2.zero;
            }
        }

        SetAnimatorTurn();
    }

    public void RunRight(bool isRunningStarts)
    {
        _isRunningRight = isRunningStarts;
        
        if (isRunningStarts)
        {
            if (_isRunningLeft)
            {
                _direction = Vector2.zero;
            } 
            else
            {
                _direction = Vector2.right;
            }
        }
        else
        {
            if (_isRunningLeft)
            {
                _direction = Vector2.left;
            }
            else
            {
                _direction = Vector2.zero;
            }
        }

        SetAnimatorTurn();
    }

    private void SetAnimatorTurn()
    {
        if (_direction == Vector2.left)
        {
            _animator.SetBool("isRunningLeft", true);
            _animator.SetBool("isRunningRight", false);
        }

        if (_direction == Vector2.right)
        {
            _animator.SetBool("isRunningLeft", false);
            _animator.SetBool("isRunningRight", true);
        }

        if (_direction == Vector2.zero)
        {
            _animator.SetBool("isRunningLeft", false);
            _animator.SetBool("isRunningRight", false);
        }
    }

    private void Run()
    {
        if (_direction == Vector2.left)
        {
            _rigidbody2D.velocity = new Vector2(-1 * _speed, _rigidbody2D.velocity.y);
        }

        if (_direction == Vector2.right)
        {
            _rigidbody2D.velocity = new Vector2(_speed, _rigidbody2D.velocity.y);
        }
    }
}
