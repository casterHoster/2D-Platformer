using UnityEngine;
using UnityEngine.Events;

public class LifeController : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private HealthView _healthView;

    private Health _health;

    public event UnityAction<float, float> HealthChanged;

    private void Start()
    {
        _health = new Health(_maxHealth);   
        _healthView.BuildHealthBar(_health);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.TryGetComponent<HitBox>(out HitBox hitBox))
        {
            _health.DecreaseValue();

            if (_health.CurrentValue <= 0)
            {
                Destroy(gameObject);
                _healthView.StopDraw(_health);
            }

            HealthChanged?.Invoke(_health.CurrentValue, _health.MaxValue);
        }

        if (collision.TryGetComponent<FirstAidKit>(out FirstAidKit firstaidkit) && gameObject.TryGetComponent<PersonMovement>(out PersonMovement personMovement))
        {
            _health.IncreaseValue();
            HealthChanged?.Invoke(_health.CurrentValue, _health.MaxValue);
        }
    }
}
