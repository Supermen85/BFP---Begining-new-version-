using System.Collections;
using UnityEngine;

public class SmoothBarRenderer : BarRenderer
{
    private Coroutine _changeCoroutine;

    private bool _isChanging = false;

    public override void ChangeValue(float value, float maxValue)
    {
        if (_isChanging)
        {
            StopCoroutine(_changeCoroutine);

            SliderBar.value = CurrentValue;

            _changeCoroutine = StartCoroutine(SmoothChange(value));
        }
        else
        {
            _isChanging = true;
            _changeCoroutine = StartCoroutine(SmoothChange(value));
        }
    }

    private IEnumerator SmoothChange(float value)
    {
        float previousValue = CurrentValue;
        CurrentValue = value;

        float speed = 3f;
        float time = 0.1f;

        var pause = new WaitForSeconds(time);

        while (previousValue != value)
        {
            SliderBar.value = Mathf.MoveTowards(SliderBar.value, value, speed);

            yield return pause;
        }

        _isChanging = false;
    }
}
