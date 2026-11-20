using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _pause = 0.1f;

    public event Action IsElapsed;
    public event Action<float> TimeSkipped;

    public void Activate(float seconds)
    {
        StartCoroutine(Change(seconds));
    }

    private IEnumerator Change(float seconds)
    {
        float elapsedTime = 0;
        var pause = new WaitForSeconds(_pause);

        while (elapsedTime < seconds)
        {
            elapsedTime += _pause;

            TimeSkipped?.Invoke(elapsedTime);

            yield return pause;
        }

        IsElapsed?.Invoke();
    }
}
