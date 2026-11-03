using System;
using UnityEngine;

public class DamageTaker : MonoBehaviour
{
    public Action<Vector2, int> Damaged;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
            Damaged?.Invoke(enemy.transform.position, enemy.Damage);
    }
}
