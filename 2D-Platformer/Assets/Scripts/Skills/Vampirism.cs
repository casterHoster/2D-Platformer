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

    public event UnityAction<float> IsActivated;

    public float Range { get => _range; }

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
        StartCoroutine(TryCollision());
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

    private IEnumerator TryCollision()
    {
        WaitForSeconds update = new WaitForSeconds(0.1f);

        while (true)
        {
            var hitColliders = Physics2D.OverlapCircleAll(transform.position, _range);

            foreach (var collider in hitColliders)
            {
                if (collider.TryGetComponent(out Patrol patrol) && collider.TryGetComponent(out HealthChange enemyHealth)
                    && _skill.IsActive == true && _canUse && !_health.Equals(enemyHealth))
                {
                    DrinkHealth(enemyHealth);
                    StartCoroutine(Delay());
                }
            }

            yield return update;
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
