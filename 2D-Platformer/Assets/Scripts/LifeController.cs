using UnityEngine;

public class LifeController : MonoBehaviour
{
    [SerializeField] private int _health;

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

        if (collision.TryGetComponent<Firstaidkit>(out Firstaidkit firstaidkit) && gameObject.TryGetComponent<PersonMovement>(out PersonMovement personMovement))
        {
            _health++;
        }
    }
}
