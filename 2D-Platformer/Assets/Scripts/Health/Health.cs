using UnityEngine;
using UnityEngine.Events;

public class Health
{
    private float _maxValue;
    private float _currentValue;

    public float MaxValue { get => _maxValue; }

    public float CurrentValue { get => _currentValue; }

    public event UnityAction<float, float> ChangedCount;

    public Health(float maxHealth)
    {
        _currentValue = maxHealth;
        _maxValue = maxHealth;
    }

    public void DecreaseValue()
    {
        _currentValue --;

        ChangedCount?.Invoke(_currentValue, _maxValue);
    }

    public void IncreaseValue()
    {
        _currentValue++;

        if (_currentValue > _maxValue)
        {
            _currentValue = _maxValue;
        }

        ChangedCount?.Invoke(_currentValue, _maxValue);
    }
}

