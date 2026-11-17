using System;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public event Action Grounded;

    public bool IsGrounded { get; private set; } = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Floor>() != null)
        {
            IsGrounded = true;
            Grounded?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Floor>() != null)
            IsGrounded = false;
    }
}
