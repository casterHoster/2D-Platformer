using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Jump : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _ground;
    [SerializeField] private float _radiusTestingGround;
    [SerializeField] private Transform pointForTestGround;

    private Rigidbody2D _rigidbody;
    private bool isOnGround;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        isOnGround = Physics2D.OverlapCircle(pointForTestGround.position, _radiusTestingGround, _ground);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && isOnGround)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce);
        }
    }
}
