using UnityEngine;
using UnityEngine.UI;

public class SliderHpView : HpView
{
    [SerializeField] Slider _hpSlider;

    protected override void DrawValue(float current, float max)
    {
        _hpSlider.maxValue = max;
        _hpSlider.value = current;
    }
}
