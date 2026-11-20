using System;
using UnityEngine;

public class LifeDrain : Changeable
{
    [SerializeField] private EnemiesDetector _enemiesDetector;
    [SerializeField] private float _durationSeconds = 6f;
    [SerializeField] private float _cooldownSeconds = 4f;
    [SerializeField] private float _drainPower = 0.7f;
    [SerializeField] private float _healPower = 0.5f;

    public override float GetMaxValue => _durationSeconds;

    private Timer _timer;
    private bool _isActive = false;
    private bool _isOnCooldown = false;

    public event Action<bool> ActivateChanged;
    public event Action<float> Healed;
    public override event Action<float, float> ValueChanged;

    private void Awake()
    {
        _timer = GetComponent<Timer>();
    }

    private void OnEnable()
    {
        _timer.IsElapsed += ChangeState;
        _timer.TimeSkipped += Tick;
    }

    private void OnDisable()
    {
        _timer.IsElapsed -= ChangeState;
        _timer.TimeSkipped -= Tick;
    }

    public void Activate()
    {
        if (_isActive == true || _isOnCooldown == true)
            return;
        
        _isActive = true;
        ActivateChanged?.Invoke(true);

        _timer.Activate(_durationSeconds);
    }

    private void Tick(float elapsedTime)
    {
        if (_isActive && _enemiesDetector.IsEnemyInRange)
        {
            Heal();
            DamageEnemies();
            ValueChanged?.Invoke(_durationSeconds - elapsedTime, _durationSeconds);
        }

        if (_isOnCooldown)
            ValueChanged?.Invoke(elapsedTime, _cooldownSeconds);
    }

    private void Heal()
    {
        Healed?.Invoke(_healPower);
    }

    private void DamageEnemies()
    {
        Enemy enemy = _enemiesDetector.GetClosestEnemy();
        enemy.TakeDamage(_drainPower);
    }

    private void ChangeState()
    {
        if (_isOnCooldown)
        {
            _isOnCooldown = false;
        }

        if (_isActive)
        {
            _isActive = false;
            _isOnCooldown = true;
            ActivateChanged?.Invoke(false);
            _timer.Activate(_cooldownSeconds);
        }
    }
}
