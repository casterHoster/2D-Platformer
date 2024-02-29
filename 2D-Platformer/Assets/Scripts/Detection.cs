using UnityEngine;
using UnityEngine.Events;

public class Detection : MonoBehaviour
{
    [SerializeField] private LayerMask _playerLayerMask;

    private float _rayLength = 5;

    public event UnityAction TargetIsFound;

    public Transform _target { get; private set; }

    private void FixedUpdate()
    {
        if (_target == null)
        {
            _target = Detect();
        }
        else
        {
            TargetIsFound?.Invoke();
        }
    }

    private Transform Detect()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, _rayLength);

        if (hitInfo.collider != null && hitInfo.collider.TryGetComponent(out PersonMovement person))
        {
            return person.transform;
        }

        return null;
    }
}
