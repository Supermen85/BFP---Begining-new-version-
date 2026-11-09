using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxAmount = 3;

    public Action Died;

    private int _amount;

    private void Awake()
    {
        _amount = _maxAmount;
    }

    public void Heal(Medkit medkit)
    {
        _amount = Mathf.Min(_maxAmount, _amount + medkit.GetValue());
    }

    public void TakeDamge(int damage)
    {
        _amount = Mathf.Max(0, _amount - damage);

        if (IsDead())
            Died?.Invoke();
    }

    private bool IsDead()
    {
        return _amount <= 0;
    }
}
