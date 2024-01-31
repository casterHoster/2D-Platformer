using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeController : MonoBehaviour
{
    [SerializeField] private int _health = 3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "AttackHitBox")
        {
            _health--;

            if (_health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
