using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;

    public Action Died;

    private int _currentHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void Heal(Medkit medkit)
    {
        _currentHealth = Mathf.Min(_maxHealth, _currentHealth + medkit.GetValue());
        Show();
    }

    public void TakeDamge(int damage)
    {
        _currentHealth = Mathf.Max(0, _currentHealth - damage);
        Show();

        if (IsDead())
            Died?.Invoke();
    }

    private void Show()
    {
        Debug.Log($"У вас {_currentHealth} HP");
    }

    private bool IsDead()
    {
        if (_currentHealth <= 0)
        {
            Debug.Log("Вы погибли!");
            return true;
        }

        return false;
    }
}
