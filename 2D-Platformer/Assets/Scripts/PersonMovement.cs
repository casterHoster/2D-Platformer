using UnityEngine;

public class PersonMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Quaternion _rotation;
    private float _leftTurnDegree;
    private float _rightTurnDegree;

    private void Awake()
    {
        _rotation = transform.rotation;
        _leftTurnDegree = 180f;
        _rightTurnDegree = 0.0f;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Follow(_leftTurnDegree);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Follow(_rightTurnDegree);
        }
    }

    private void Follow(float turnDegree)
    {
        _rotation.y = turnDegree;
        transform.rotation = _rotation;
        transform.Translate(_speed * Time.deltaTime, 0, 0);
    }
}
