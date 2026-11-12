using UnityEngine;

public class Bar<T> : MonoBehaviour where T : BarRenderer
{
    [SerializeField] private Health _health;

    private T _barRender;

    private void Awake()
    {
        _barRender = GetComponent<T>();
    }

    private void Start()
    {
        _barRender.SetStartingValue(_health.MaxAmount);
    }

    private void OnEnable()
    {
        _health.ValueChanged += ChangeValue;
    }

    private void OnDisable()
    {
        _health.ValueChanged -= ChangeValue;
    }

    private void ChangeValue(float value, float maxValue)
    {
        _barRender.ChangeValue(value, maxValue);
    }
 }
