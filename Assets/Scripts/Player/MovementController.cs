using UnityEngine;

[RequireComponent(typeof(Jumper))]
[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(AnimationController))]
[RequireComponent(typeof(GroundChecker))]

public class MovementController : MonoBehaviour
{
    private Mover _mover;
    private Jumper _jumper;
    private AnimationController _animationController;
    private GroundChecker _groundChecker;

    private Vector2 _direction = Vector2.zero;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _jumper = GetComponent<Jumper>();
        _animationController = GetComponent<AnimationController>();
        _groundChecker = GetComponentInChildren<GroundChecker>();
    }

    private void OnEnable()
    {
        _groundChecker.Grounded += Land;
    }

    private void OnDisable()
    {
        _groundChecker.Grounded -= Land;
    }

    public void Knockback(Vector2 enemyPosition)
    {
        _mover.Knockback(enemyPosition);
    }

    public void Run()
    {
        if (_direction != Vector2.zero)
            _mover.Run(_direction);
    }

    public void Jump()
    {
        if (_groundChecker.CanJump())
        {
            _jumper.Jump();
            _animationController.Jump();
        }
    }

    public void StartRunLeft()
    {
        if (_direction == Vector2.zero)
            _direction = Vector2.left;

        if (_direction == Vector2.right)
            _direction = Vector2.zero;
        
        _animationController.SetAnimation(_direction);
    }

    public void StopRunLeft()
    {
        if (_direction == Vector2.zero)
            _direction = Vector2.right;

        if (_direction == Vector2.left)
            _direction = Vector2.zero;

        _animationController.SetAnimation(_direction);
    }

    public void StartRunRight()
    {
        if (_direction == Vector2.zero)
            _direction = Vector2.right;

        if (_direction == Vector2.left)
            _direction = Vector2.zero;
    
        _animationController.SetAnimation(_direction);
    }

    public void StopRunRight()
    {
        if (_direction == Vector2.zero)
            _direction = Vector2.left;

        if (_direction == Vector2.right)
            _direction = Vector2.zero;

        _animationController.SetAnimation(_direction);
    }

    private void Land()
    {
        _animationController.Land();
    }
}
