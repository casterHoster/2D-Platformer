using UnityEngine;

public class PersonMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Controller _controller;

    private Quaternion _rotation;
    private float _leftTurnDegree;
    private float _rightTurnDegree;

    private void Awake()
    {
        _rotation = transform.rotation;
        _leftTurnDegree = 180f;
        _rightTurnDegree = 0.0f;
        _controller.KeyPassed += TryUseAttackKey;
    }

    private void TryUseAttackKey(KeyCode keyCode)
    {
        if (keyCode == KeyCode.A)
        {
            Follow(_leftTurnDegree);
        }

        if (keyCode == KeyCode.D)
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
