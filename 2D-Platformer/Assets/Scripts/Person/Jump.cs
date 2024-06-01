using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Jump : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _ground;
    [SerializeField] private float _radiusTestingGround;
    [SerializeField] private Transform pointForTestGround;
    [SerializeField] private Controller _controller;

    private Rigidbody2D _rigidbody;
    private bool isOnGround;
    private bool _isKeyDown = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _controller.KeyPassed += TryUseAttackKey;
    }

    private void FixedUpdate()
    {
        isOnGround = Physics2D.OverlapCircle(pointForTestGround.position, _radiusTestingGround, _ground);

        if (_isKeyDown == true )
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce);
            _isKeyDown = false;
        }
    }

    private void TryUseAttackKey(KeyCode keyCode)
    {
        if (keyCode == KeyCode.W && isOnGround)
        {
            _isKeyDown = true;
        }
    }
}
