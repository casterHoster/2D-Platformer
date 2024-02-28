using UnityEngine;

public class Firstaidkit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PersonMovement>(out PersonMovement movement))
        {
            Destroy(gameObject);
        }
    }
}
