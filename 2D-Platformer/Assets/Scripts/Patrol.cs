using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Patrol : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;
    [SerializeField] private LayerMask _layerMask;

    private Transform[] _points;
    private int _currentPoint;
    private float _leftTurnDegree = 180f;
    private float _rightTurnDegree = 0.0f;
    private Transform _target;
    private Detection detection;
    private bool _isSeePlayer = false;

    private void Start()
    {
        detection = GetComponentInChildren<Detection>();
        detection.TargetIsFound += SeePlayer;
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }

    }

   private void Update()
    {
        if (_isSeePlayer)
        {
            ChangeTargetPlayer();
        }
        else
        {
        _target = _points[_currentPoint];
        }

        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
        Turn(_target);

        if (_target == _points[_currentPoint] && transform.position == _target.position)
        {
            _currentPoint++;

            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }
    }


    private void Turn(Transform target)
    {
        if (target.position.x >= transform.position.x)
        {
            var nextRotation = transform.rotation;
            nextRotation.y = _rightTurnDegree;
            transform.rotation = nextRotation;
        }
        else
        {
            var nextRotation = transform.rotation;
            nextRotation.y = _leftTurnDegree;
            transform.rotation = nextRotation;
        }
    }

    private void ChangeTargetPlayer()
    {
        _target = detection._target;
    }

    private void SeePlayer()
    {
        _isSeePlayer = true;
    }
}
