using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    public void Jump()
    {
        _animator.SetBool("isJumping", true);
    }

    public void Land()
    {
        _animator.SetBool("isJumping", false);
    }

    public void SetAnimation(Vector2 direction)
    {
        if (direction == Vector2.left)
        {
            _animator.SetBool("isRunningLeft", true);
            _animator.SetBool("isRunningRight", false);
        }

        if (direction == Vector2.right)
        {
            _animator.SetBool("isRunningLeft", false);
            _animator.SetBool("isRunningRight", true);
        }

        if (direction == Vector2.zero)
        {
            _animator.SetBool("isRunningLeft", false);
            _animator.SetBool("isRunningRight", false);
        }
    }
}
