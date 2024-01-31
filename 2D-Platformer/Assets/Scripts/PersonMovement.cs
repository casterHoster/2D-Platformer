using UnityEngine;

public class PersonMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Quaternion rotation;
    private float leftTurnDegree;
    private float rightTurnDegree;

    private void Awake()
    {
        rotation = transform.rotation;
        leftTurnDegree = 180f;
        rightTurnDegree = 0.0f;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Follow(leftTurnDegree);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Follow(rightTurnDegree);
        }   
    }

    private void Follow(float turnDegree)
    {
        rotation.y = turnDegree;
        transform.rotation = rotation;
        transform.Translate(_speed * Time.deltaTime, 0, 0);
    }
}
