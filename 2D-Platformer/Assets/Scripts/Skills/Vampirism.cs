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
    [SerializeField] private Health _health;
    [SerializeField] private float _bitePower;
    [SerializeField] private Controller _controller;

    private Skill _skill;
    private bool _canUse = true;

    public event UnityAction<float> IsActivated;

    public float Range { get => _range; }

    private void Start()
    {
        _skill = new Skill(_range);
        _controller.KeyPassed += TryUseAttackKey;
    }

    private void TryUseAttackKey(KeyCode keyCode)
    {
        if (keyCode == KeyCode.E && _skill.IsActive == false)
        {
            IsActivated?.Invoke(_skillTime);
            StartCoroutine(SkillActivate());
            StartCoroutine(TryCollision());
        }
    }

    private void DrinkHealth(Health enemyHealth)
    {
        _health.IncreaseHealth(_bitePower);
        enemyHealth.DecreaseHealth(_bitePower);
    }

    private IEnumerator TryCollision()
    {
        WaitForSeconds update = new WaitForSeconds(0.1f);

        while (true)
        {
            var hitColliders = Physics2D.OverlapCircleAll(transform.position, _range);

            foreach (var collider in hitColliders)
            {
                if (_skill.IsActive && _canUse && collider.TryGetComponent(out Patrol patrol) && collider.TryGetComponent(out Health enemyHealth)
                    && !_health.Equals(enemyHealth))
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
