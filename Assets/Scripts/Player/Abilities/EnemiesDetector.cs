using System.Collections.Generic;
using UnityEngine;

public class EnemiesDetector : MonoBehaviour
{
    public bool IsEnemyInRange => _enemiesInRange.Count > 0;

    private List<Enemy> _enemiesInRange = new List<Enemy>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
            _enemiesInRange.Add(enemy);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
            _enemiesInRange.Remove(enemy);
    }

    public Enemy GetClosestEnemy()
    {
        if (_enemiesInRange.Count == 0) 
            return null;

        int index = 0;

        Enemy closestEnemy = _enemiesInRange[index];

        float minDistance = (_enemiesInRange[index].transform.position - transform.position).sqrMagnitude;
        
        float distance = 0;

        while (++index < _enemiesInRange.Count)
        {
            distance = (_enemiesInRange[index].transform.position - transform.position).sqrMagnitude;
            
            if (distance < minDistance)
            {
                minDistance = distance;
                closestEnemy = _enemiesInRange[index];
            }
        }

        return closestEnemy;
    }
}
