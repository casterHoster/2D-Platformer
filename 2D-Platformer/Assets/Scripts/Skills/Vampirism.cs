using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Vampirism : MonoBehaviour
{
    [SerializeField] private float _range;
    [SerializeField] private int _skillTime;
    [SerializeField] private int _cooldownTick;
    [SerializeField] private List<LayerMask> _excludes;
    [SerializeField] private HealthChange _health;

    private Skill _skill;
    private CircleCollider2D _circleSkillRadius;
    
    private bool _canUse = true;

    public float Range { get => _range; }

    public event UnityAction<float> IsActivated;

    private void Awake()
    {
        _circleSkillRadius = gameObject.AddComponent<CircleCollider2D>();
        _circleSkillRadius.isTrigger = true;
        _circleSkillRadius.radius = _range;

        foreach (LayerMask excude in _excludes)
        {
            _circleSkillRadius.excludeLayers = excude;
        }
    }

    private void Start()
    {
        _skill = new Skill(_range);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _skill.IsActive == false)
        {
            IsActivated?.Invoke(_skillTime);
            StartCoroutine(SkillActivate());
        }
    }
    private void DrinkHealth(HealthChange enemyHealth)
    {
        _health.IncreaseHealth();
        enemyHealth.DecreaseHealth();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Patrol patrol) && collision.TryGetComponent(out HealthChange enemyHealth) && _skill.IsActive == true && _canUse)
        {
            if (!_health.Equals(enemyHealth))
            {
                DrinkHealth(enemyHealth);
                StartCoroutine(Delay());
            }
        }
    }

    private IEnumerator SkillActivate()
    {
        _skill.ChangeActivity();
        yield return new WaitForSeconds(_skillTime);
        _skill.ChangeActivity();
    }

    private IEnumerator Delay()
    {
        if (_canUse == true)
        {
            _canUse = false;
            yield return new WaitForSeconds(_cooldownTick);
            _canUse = true;
        }
    }
}
