using System.Collections;
using UnityEngine;

public class PersonAttack : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _attackHitBox;

    private Animator animator;

    private void Start()
    {
        _attackHitBox.enabled = false;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.Play("PersonAttack");
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
