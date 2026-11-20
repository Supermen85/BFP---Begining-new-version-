using System;
using UnityEngine;

public abstract class DamageTaker<T> : MonoBehaviour where T : IAttackable
{
    public event Action<Vector3, float> DamagedWithKnockback;
    public event Action<float> Damaged;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out T attackable))
        {
            DamagedWithKnockback?.Invoke(attackable.Position, attackable.Damage);
            Damaged?.Invoke(attackable.Damage);
        }
    }
}
