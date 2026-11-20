using System;
using UnityEngine;

public class Health : Changeable
{
    [SerializeField] private float _maxAmount = 100;

    public override float GetMaxValue => _maxAmount;
    private bool IsDead => _amount <= 0;

    private float _amount;

    public event Action Died;
    public override event Action<float, float> ValueChanged;

    private void Awake()
    {
        _amount = _maxAmount;
    }

    public void Heal(float amount)
    {
        _amount = Mathf.Min(_maxAmount, _amount + amount);

        ValueChanged?.Invoke(_amount, _maxAmount);
    }

    public void TakeDamge(float damage)
    {
        _amount = Mathf.Max(0, _amount - damage);

        ValueChanged?.Invoke(_amount, _maxAmount);

        if (IsDead)
            Died?.Invoke();
    }
}
