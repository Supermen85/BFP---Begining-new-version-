using UnityEngine;
using UnityEngine.UI;

public abstract class BarRenderer : MonoBehaviour
{
    [SerializeField] protected Slider SliderBar;

    protected float CurrentValue = 100f;

    public void SetStartingValue(float value)
    {
        CurrentValue = value;

        SliderBar.minValue = 0;
        SliderBar.maxValue = value;

        SliderBar.value = value;
    }

    public abstract void ChangeValue(float value, float maxValue);
}

