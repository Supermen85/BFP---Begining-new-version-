using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] protected int _value = 1;

    public event Action Picked;

    public void SetPosition(Vector2 position)
    {
        transform.position = position;
    }

    public void Pick()
    {
        Picked?.Invoke();
    }

    public int GetValue()
    {
        return _value;
    }
}
