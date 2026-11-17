public class InstantBarRenderer : BarRenderer
{
    public override void ChangeValue(float value, float maxValue)
    {
        if (SliderBar.maxValue != maxValue)
            SliderBar.maxValue = maxValue;

        SliderBar.value = value;
    }
}
