using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : HealthView
{
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Transform _ownerTransform;
    [SerializeField] private LifeController _ownerLifeController;
    [SerializeField] private Slider _slider;

    private void Start()
    {
        _slider.value = 1;
        _slider.maxValue = 100;
    }

    private void Update()
    {
        _slider.transform.position = Camera.main.WorldToScreenPoint(_ownerTransform.position + _offset);
    }

    protected override void DrawHealthValue(float currentValue, float maxValue)
    {
        _slider.value = currentValue;
        _slider.maxValue = maxValue;
    }

    protected override void BreakHealthBar()
    {
        Destroy(gameObject);
    }
}
