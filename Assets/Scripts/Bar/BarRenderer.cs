using UnityEngine;
using UnityEngine.UI;

public abstract class BarRenderer : MonoBehaviour
{
    [SerializeField] protected Slider SliderBar;
    [SerializeField] protected Changeable Changeable;

    protected float CurrentValue = 100f;

    private void Start()
    {
        SetStartingValue(Changeable.GetMaxValue);
    }

    private void OnEnable()
    {
        Changeable.ValueChanged += ChangeValue;
    }

    private void OnDisable()
    {
        Changeable.ValueChanged -= ChangeValue;
    }

    public void SetStartingValue(float value)
    {
        CurrentValue = value;

        SliderBar.minValue = 0;
        SliderBar.maxValue = value;

        SliderBar.value = value;
    }

    public abstract void ChangeValue(float value, float maxValue);
}

