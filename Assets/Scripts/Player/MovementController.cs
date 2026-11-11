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

    public void Run(Vector2 direction)
    {
        if (direction == Vector2.left)
            _mover.RunLeft();

        if (direction == Vector2.right)
            _mover.RunRight();

        _animationController.SetAnimation(direction);
    }

    public void Jump()
    {
        if (_groundChecker.IsGrounded)
        {
            _jumper.Jump();
            _animationController.Jump();
        }
    }

    private void Land()
    {
        _animationController.Land();
    }
}
