using System;
using UnityEngine;

public class ItemCollector<T> : MonoBehaviour where T : Item
{
    public event Action<T> Picked;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        T item = collision.GetComponent<T>();
        
        if (item != null)
        {
            item.Pick();
            Picked?.Invoke(item);
        }
    }
}
