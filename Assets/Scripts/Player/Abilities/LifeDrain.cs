using System;
using UnityEngine;

public class LifeDrain : MonoBehaviour
{
    [SerializeField] private float _drainPower = 0.7f;
    [SerializeField] private float _healPower = 0.5f;

    public event Action<bool> ActivateChanged;
    public event Action<float> Healed;

    private EnemiesCounter _enemiesCounter; 
    private Timer _timer;

    private void Awake()
    {
        _enemiesCounter = GetComponentInChildren<EnemiesCounter>();
        _timer = GetComponentInChildren<Timer>();
    }

    private void OnEnable()
    {
        _timer.IsElapsed += Deactivate;
        _timer.Tick += Drain;
    }

    private void OnDisable()
    {
        _timer.IsElapsed -= Deactivate;
        _timer.Tick -= Drain;
    }

    public void Activate()
    {
        if (_timer.CanCast == false)
            return;

        ActivateChanged?.Invoke(true);
        _timer.StartDuration();
    }

    private void Drain()
    {
        Heal();
        DamageEnemies();
    }

    private void Heal()
    {
        float heal = _enemiesCounter.EnemiesInRange.Count * _healPower;

        Healed?.Invoke(heal);
    }

    private void DamageEnemies()
    {
        int count = 0;

        while (count < _enemiesCounter.EnemiesInRange.Count)
        {
            _enemiesCounter.EnemiesInRange[count].TakeDamage(_drainPower);
            count++;
        }
    }

    private void Deactivate()
    {
        ActivateChanged?.Invoke(false);
    }
}
