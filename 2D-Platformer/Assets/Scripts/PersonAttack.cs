using System.Collections;
using UnityEngine;

public class PersonAttack : MonoBehaviour
{
    [SerializeField] private GameObject _attackHitBox; 

    private Animator animator;

    private void Start()
    {
        _attackHitBox.SetActive(false);
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            animator.Play("PersonAttack");
            StartCoroutine(DoAttack());
        }
    }

    private IEnumerator DoAttack()
    {
        _attackHitBox.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        _attackHitBox.SetActive(false);
    }
}
