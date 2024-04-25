using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class HealthText : HealthView
{
    private Text _text;

    private void Start()
    {
        _text = GetComponent<Text>();
    }

    protected override void DrawHealthValue(float currentValue, float maxValue)
    {
        _text.text = $"{currentValue}/{maxValue}";
    }
}
