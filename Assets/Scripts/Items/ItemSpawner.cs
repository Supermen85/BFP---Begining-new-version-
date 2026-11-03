using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
   private List<Transform> _spawnPoints;

    private Renderer _renderer;
    private Collider2D _collider;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _collider = GetComponent<Collider2D>();
    }

    public void SetSpawnPoints(List<Transform> spawnPoints)
    {
        _spawnPoints = spawnPoints;
    }

    public void Spawn()
    {
        _renderer.enabled = false;
        _collider.enabled = false;

        SetRandomPosition();

        StartCoroutine(Enable());
    }

    private void SetRandomPosition()
    {
        transform.position = _spawnPoints[Random.Range(0, _spawnPoints.Count)].position;
    }

    private IEnumerator Enable()
    {
        int time = 2;
        var wait = new WaitForSeconds(time);

        yield return wait;

        while (CanSpawn() == false)
        {
            yield return wait;
        }

        _renderer.enabled = true;
        _collider.enabled = true;
    }

    private bool CanSpawn()
    {
        float radius = 0.4f;
        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (Collider2D collider in colliders)
        {
            if (collider.GetComponent<Player>() == true)
                return false;
        }

        return true;
    }
}
