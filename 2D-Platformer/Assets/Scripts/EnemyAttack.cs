using System.Collections;
using UnityEngine;

[RequireComponent (typeof(Animator))]

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private GameObject _attackHitBox;
    [SerializeField] private float _attackRange;
    [SerializeField] private LayerMask _playerLayerMask;

    const string AttackAnimation = "EnemyAttack";

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
                _animator.Play(AttackAnimation);
                StartCoroutine(WaitBeforeStrike());
                StopCoroutine(WaitBeforeStrike());
                StartCoroutine(DoAttack());
                StopCoroutine(DoAttack());
                _isDoingCooldown = true;
                StartCoroutine(Cooldown());
                StopCoroutine(Cooldown());
            }
        }
    }

    private IEnumerator DoAttack()
    {
        _attackHitBox.SetActive(true);
        yield return new WaitForSeconds(_hitBoxActiveTime);
        _attackHitBox.SetActive(false);
    }

    private IEnumerator WaitBeforeStrike()
    {
        yield return new WaitForSeconds(_waitingTime);
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(_cooldownTime);
        _isDoingCooldown = false;
    }
}
