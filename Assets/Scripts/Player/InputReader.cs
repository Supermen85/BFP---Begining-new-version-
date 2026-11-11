using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action Jumped;

    public Vector2 Direction { get; private set; } = Vector2.zero;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            Jumped?.Invoke();

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            StartRunLeft();

        if (Input.GetKeyDown(KeyCode.RightArrow))
            StartRunRight();

        if (Input.GetKeyUp(KeyCode.LeftArrow))
            StopRunLeft();

        if (Input.GetKeyUp(KeyCode.RightArrow))
            StopRunRight();
    }

    private void StartRunLeft()
    {
        if (Direction == Vector2.zero)
            Direction = Vector2.left;

        if (Direction == Vector2.right)
            Direction = Vector2.zero;
    }

    private void StopRunLeft()
    {
        if (Direction == Vector2.zero)
            Direction = Vector2.right;

        if (Direction == Vector2.left)
            Direction = Vector2.zero;
    }

    private void StartRunRight()
    {
        if (Direction == Vector2.zero)
            Direction = Vector2.right;

        if (Direction == Vector2.left)
            Direction = Vector2.zero;
    }

    private void StopRunRight()
    {
        if (Direction == Vector2.zero)
            Direction = Vector2.left;

        if (Direction == Vector2.right)
            Direction = Vector2.zero;
    }
}
