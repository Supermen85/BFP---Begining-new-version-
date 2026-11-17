using System;
using System.Collections;
using UnityEngine;

public class Cooldown : MonoBehaviour
{
    [field: SerializeField] public float Seconds { get; private set; } = 4f;

    [SerializeField] private float _pause = 0.1f;

    public event Action IsElapsed;
    public event Action<float, float> ValueChanged;

    public void Activate()
    {
        StartCoroutine(Change());
    }

    private IEnumerator Change()
    {
        float elapsedTime = 0;
        var pause = new WaitForSeconds(_pause);

        while (elapsedTime < Seconds)
        {
            elapsedTime += _pause;

            ValueChanged?.Invoke(elapsedTime, Seconds);

            yield return pause;
        }

        IsElapsed?.Invoke();
    }
}
