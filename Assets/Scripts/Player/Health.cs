using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [field: SerializeField] public int MaxAmount { get; private set; } = 100;

    public event Action Died;
    public event Action<float, float> ValueChanged;

    private int _amount;

    private void Awake()
    {
        _amount = MaxAmount;
    }

    public void Heal(Medkit medkit)
    {
        _amount = Mathf.Min(MaxAmount, _amount + medkit.GetValue());

        ValueChanged?.Invoke(_amount, MaxAmount);
    }

    public void TakeDamge(int damage)
    {
        _amount = Mathf.Max(0, _amount - damage);

        ValueChanged?.Invoke(_amount, MaxAmount);

        if (IsDead())
            Died?.Invoke();
    }

    private bool IsDead()
    {
        return _amount <= 0;
    }
}
