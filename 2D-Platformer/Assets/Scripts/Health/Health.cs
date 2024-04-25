using UnityEngine;
using UnityEngine.Events;

public class Health
{
    private float _maxValue;
    private float _currentValue;

    public float MaxValue { get => _maxValue; }

    public float CurrentValue { get => _currentValue; }

    public Health(float maxHealth)
    {
        _currentValue = maxHealth;
        _maxValue = maxHealth;
    }

    public event UnityAction<float, float> ChangedCount;

    public void DecreaseValue()
    {
        _currentValue --;

        //if (_currentValue <= 0)
        //{
        //    Destroy(gameObject);
        //}
    }

    public void IncreaseValue()
    {
        _currentValue++;

        if (_currentValue > _maxValue)
        {
            _currentValue = _maxValue;
        }
    }



    //public void IncreaseValue(float value)
    //{
    //    _currentValue += value;

    //    if (_currentValue > _maxValue)
    //    {
    //        _currentValue = _maxValue;
    //    }

    //    ChangedCount?.Invoke(_currentValue, _maxValue);
    //}

    //public void DecreaseValue(float value)
    //{
    //    _currentValue -= value;

    //    if (_currentValue < 0)
    //    {
    //        _currentValue = 0;
    //    }

    //    ChangedCount?.Invoke(_currentValue, _maxValue);
    //}
}

