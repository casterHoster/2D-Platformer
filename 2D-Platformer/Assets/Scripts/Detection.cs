using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Events;

public class Detection : MonoBehaviour
{
    [SerializeField] private LayerMask _playerLayerMask;

    public event UnityAction TargetIsFound;

    private float _rayLength = 5;
    public Transform _target { get; private set;}


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
        Debug.DrawRay(transform.position, transform.right * _rayLength);

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, _rayLength);

        if (hitInfo.collider != null && hitInfo.collider.TryGetComponent(out PersonMovement person))
        {
            return person.transform;
        }

        return null;
    }


}
