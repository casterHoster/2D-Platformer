using System;

public class HP
{
    private float _max;
    private float _current;

    public float Max { get => _max; }
    public float Current { get => _current; }   

    public event Action<float, float> OnHpChanged;

    public HP(float max)
    {
        _max = max;
        _current = max;
    }

    public void SetDamage(float damage)
    {
        _current -= damage;
        if(_current < 0)
            _current = 0;

        OnHpChanged?.Invoke(_current, _max);
    }

    public void Heal(float healValue)
    {
        _current += healValue;
        if(_current > _max)
            _current = _max;
        OnHpChanged?.Invoke(_current, _max);
    }
}
