using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public static readonly int IsJumping = Animator.StringToHash(nameof(IsJumping));
    public static readonly int IsRunningLeft = Animator.StringToHash(nameof(IsRunningLeft));
    public static readonly int IsRunningRight = Animator.StringToHash(nameof(IsRunningRight));

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    public void Jump()
    {
        _animator.SetBool(IsJumping, true);
    }

    public void Land()
    {
        _animator.SetBool(IsJumping, false);
    }

    public void SetAnimation(Vector2 direction)
    {
        if (direction == Vector2.left)
        {
            _animator.SetBool(IsRunningLeft, true);
            _animator.SetBool(IsRunningRight, false);
        }

        if (direction == Vector2.right)
        {
            _animator.SetBool(IsRunningLeft, false);
            _animator.SetBool(IsRunningRight, true);
        }

        if (direction == Vector2.zero)
        {
            _animator.SetBool(IsRunningLeft, false);
            _animator.SetBool(IsRunningRight, false);
        }
    }
}
