using UnityEngine;

public class DistanceChecker : MonoBehaviour
{
    [SerializeField] private float _min = 0.2f;

    public bool IsCloseEnough(Vector2 checkpoint)
    {
        return (checkpoint - (Vector2)transform.position).sqrMagnitude < _min * _min;
    }
}
