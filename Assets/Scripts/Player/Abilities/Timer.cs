using System;
using UnityEngine;

[RequireComponent(typeof(Duration))]
[RequireComponent(typeof(Cooldown))]

public class Timer : MonoBehaviour, IBarable
{
    private Duration _duration;
    private Cooldown _cooldown;

    public event Action<float, float> ValueChanged;
    public event Action IsElapsed;
    public event Action Tick;

    public bool CanCast { get; private set; } = true;

    private void Awake()
    {
        _duration = GetComponent<Duration>();
        _cooldown = GetComponent<Cooldown>();
    }

    private void OnEnable()
    {
        _duration.ValueChanged += ValueChangeOnDuration;
        _duration.IsElapsed += ChangeState;
        _cooldown.ValueChanged += ValueChangeOnCooldown;
        _cooldown.IsElapsed += Recharge;
    }

    private void OnDisable()
    {
        _duration.ValueChanged -= ValueChangeOnDuration;
        _duration.IsElapsed -= ChangeState;
        _cooldown.ValueChanged -= ValueChangeOnCooldown;
        _cooldown.IsElapsed -= Recharge;

    }

    public float GetMaxValue()
    {
        return _duration.Seconds;
    }

    public void StartDuration()
    {
        CanCast = false;
        _duration.Activate();
    }

    private void ChangeState()
    {
        IsElapsed?.Invoke();
        StartCooldown();
    }

    private void StartCooldown()
    {
        _cooldown.Activate();
    }

    private void Recharge()
    {
        CanCast = true;
    }

    private void ValueChangeOnDuration(float value1, float value2)
    {
        Tick?.Invoke();
        ValueChanged?.Invoke(value1, value2);
    }

    private void ValueChangeOnCooldown(float value1, float value2)
    {
        ValueChanged?.Invoke(value1, value2);
    }
}
