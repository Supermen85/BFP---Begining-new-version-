using System;

public interface IBarable
{
    public event Action<float, float> ValueChanged;

    public float GetMaxValue();
}
