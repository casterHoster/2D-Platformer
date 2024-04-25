using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthSlider : HealthView
{
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Transform _ownerTransform;
    [SerializeField] private LifeController _ownerLifeController;

    private Slider _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _ownerLifeController.HealthChanged += DrawHealthValue;
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
}
