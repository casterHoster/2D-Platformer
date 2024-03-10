using UnityEngine;

public class LifeController : MonoBehaviour
{
    [SerializeField] private int _health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<BoxCollider2D>(out BoxCollider2D boxCollider))
        {
            _health--;

            if (_health <= 0)
            {
                Destroy(gameObject);
            }
        }

        if (collision.TryGetComponent<FirstAidKit>(out FirstAidKit firstaidkit) && gameObject.TryGetComponent<PersonMovement>(out PersonMovement personMovement))
        {
            _health++;
        }
    }
}
