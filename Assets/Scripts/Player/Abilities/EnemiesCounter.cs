using System.Collections.Generic;
using UnityEngine;

public class EnemiesCounter : MonoBehaviour
{
    private List<Enemy> _enemiesInRange = new List<Enemy>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
            _enemiesInRange.Add(enemy);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
            _enemiesInRange.Remove(enemy);
    }

    public IReadOnlyList<Enemy> EnemiesInRange => _enemiesInRange;
}
