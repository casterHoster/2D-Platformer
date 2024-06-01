using System.Collections;
using UnityEngine;

public class PersonAttack : AttackBase
{
    [SerializeField] private BoxCollider2D _attackHitBox;
    [SerializeField] private Controller _controller;

    private Animator _animator;
    private int _attackAnimation = Animator.StringToHash("PersonAttack");

    private void Start()
    {
        _attackHitBox.enabled = false;
        _animator = GetComponent<Animator>();
        _controller.KeyPassed += TryUseAttackKey;
    }

    private void TryUseAttackKey(KeyCode keyCode)
    {
        if (keyCode == KeyCode.Space) 
        {
            _animator.Play(_attackAnimation);
            StartCoroutine(DoAttack());
            StopCoroutine(DoAttack());
        }
    }

    private IEnumerator DoAttack()
    {
        _attackHitBox.enabled = true;
        yield return new WaitForSeconds(0.1f);
        _attackHitBox.enabled = false;
    }
}
