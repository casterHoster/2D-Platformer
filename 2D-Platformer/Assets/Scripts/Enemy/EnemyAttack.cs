using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class EnemyAttack : AttackBase
{
    [SerializeField] private GameObject _attackHitBox;
    [SerializeField] private float _attackRange;
    [SerializeField] private LayerMask _playerLayerMask;

    private int _attackAnimation = Animator.StringToHash("EnemyAttack");

    private Animator _animator;
    private bool _isDoingCooldown;
    private float _cooldownTime = 2f;
    private float _waitingTime = 2f;
    private float _hitBoxActiveTime = 0.1f;

    private void Start()
    {
        _attackHitBox.SetActive(false);
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (_isDoingCooldown == false)
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, _attackRange, _playerLayerMask);

            if (hitInfo.collider != null && hitInfo.collider.TryGetComponent(out PersonMovement person))
            {
                StartCoroutine(DoAttack());
                StartCoroutine(Waiting());
                StopCoroutine(DoAttack());
                StartCoroutine(Waiting());
            }
        }
    }

    private IEnumerator DoAttack()
    {
        _animator.Play(_attackAnimation);
        yield return new WaitForSeconds(_waitingTime);
        _attackHitBox.SetActive(true);
        yield return new WaitForSeconds(_hitBoxActiveTime);
        _attackHitBox.SetActive(false);
    }

    private IEnumerator Waiting()
    {
        _isDoingCooldown = true;
        yield return new WaitForSeconds(_cooldownTime);
        _isDoingCooldown = false;
    }
}