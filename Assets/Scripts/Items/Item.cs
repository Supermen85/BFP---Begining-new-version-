using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ItemSpawner))]

public class Item : MonoBehaviour
{
    [SerializeField] protected int _value = 1;

    public Action<Item> Picked;
    
    protected ItemSpawner _spawner;

    private void Awake()
    {
        _spawner = GetComponent<ItemSpawner>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
            Picked?.Invoke(this);
    }

    public void SetSpawnPoints(List<Transform> points)
    {
        _spawner.SetSpawnPoints(points);
    }

    public void Spawn()
    {
        _spawner.Spawn();
    }

    public int GetValue()
    {
        return _value;
    }
}
