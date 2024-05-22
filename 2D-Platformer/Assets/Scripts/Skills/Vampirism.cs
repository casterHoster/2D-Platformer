using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]

public class Vampirism : MonoBehaviour
{
    [SerializeField] private float _range;
    [SerializeField] private int _skillTime;
    [SerializeField] private int _cooldown;
    [SerializeField] private List<LayerMask> _excludes;

    private Skill _skill;
    private CircleCollider2D _circleSkillRadius;
    private HealthChange _health;
    private bool _canUse = true;

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
        _health = GetComponent<HealthChange>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _skill.IsActive == false)
        {
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
            yield return new WaitForSeconds(_cooldown);
            _canUse = true;
        }
    }
}
