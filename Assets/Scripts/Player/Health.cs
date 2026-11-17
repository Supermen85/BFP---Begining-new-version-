using System;
using UnityEngine;

public class Health : MonoBehaviour, IBarable
{
    [SerializeField] private float _maxAmount = 100;

    public event Action Died;
    public event Action<float, float> ValueChanged;

    private float _amount;

    private void Awake()
    {
        _amount = _maxAmount;
    }

    public float GetMaxValue()
    {
        return _maxAmount;
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

        if (IsDead())
            Died?.Invoke();
    }

    private bool IsDead()
    {
        return _amount <= 0;
    }
}
