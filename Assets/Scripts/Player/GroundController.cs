using System;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    public Action Grounded;

    private bool _isGrounded = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Floor>() != null)
        {
            _isGrounded = true;
            Grounded?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Floor>() != null)
            _isGrounded = false;
    }

    public bool CanJump()
    {
        return _isGrounded;
    }
}
