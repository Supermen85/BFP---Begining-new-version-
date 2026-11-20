using System;
using UnityEngine;

public abstract class Changeable : MonoBehaviour
{
    public abstract event Action<float, float> ValueChanged;

    public abstract float GetMaxValue { get; }

}
