using System;
using UnityEngine;

public class DamageTaker : MonoBehaviour
{
    public event Action<Vector2, float> DamagedByEnemy;
    public event Action<float> DamagedByPlayer;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
            DamagedByEnemy?.Invoke(enemy.transform.position, enemy.Damage);
        
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
            DamagedByPlayer?.Invoke(player.Damage);
    }
}
