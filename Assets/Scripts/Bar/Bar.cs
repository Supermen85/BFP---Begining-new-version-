using UnityEngine;

public class Bar<T> : MonoBehaviour where T : BarRenderer
{
    [SerializeField] private MonoBehaviour _barableObject;

    public IBarable _barable => _barableObject as IBarable;

    private T _barRender;

    private void Awake()
    {
        _barRender = GetComponent<T>();
    }

    private void Start()
    {
        _barRender.SetStartingValue(_barable.GetMaxValue());
    }

    private void OnEnable()
    {
        _barable.ValueChanged += ChangeValue;
    }

    private void OnDisable()
    {
        _barable.ValueChanged -= ChangeValue;
    }

    private void ChangeValue(float value, float maxValue)
    {
        _barRender.ChangeValue(value, maxValue);
    }
 }
