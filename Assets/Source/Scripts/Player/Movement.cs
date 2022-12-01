using UnityEngine;

[RequireComponent(typeof(Animator), typeof(SpriteRenderer), typeof(Rigidbody2D))]

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpVelocity;
    [SerializeField] private float _gravityScale;
    [SerializeField] private float _fallingGravityScale;
    [SerializeField] private float _pressedButtonTimer;
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private ParticleSystem _dustParticle;

    private Animator _animator;
    private SpriteRenderer _renderer;
    private Rigidbody2D _rigidbody;
    private float _jumpTime;
    private bool _isJumping { get; set; }
    private static class AnimatorPlayerController { public static class Params { public const string Speed = nameof(Speed); } }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Running();

        if (Input.GetKeyDown(KeyCode.Space) && _groundDetector.IsGrounded)
        {
            _isJumping = true;
            _jumpTime = 0;
        }
        if (_isJumping)
        {
            Jump(_jumpVelocity);
            _jumpTime += Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.Space) | _jumpTime > _pressedButtonTimer)
            _isJumping = false;
        ApplyGravity(_gravityScale, _fallingGravityScale);
    }

    private void Running()
    {
        var horizontalMovement = Input.GetAxis("Horizontal");
        const string IsGrounded = "isGrounded";

        _animator.SetBool(IsGrounded, _groundDetector.IsGrounded);
        _animator.SetFloat(AnimatorPlayerController.Params.Speed, Mathf.Abs(horizontalMovement));
        Vector3 movement = new Vector3(horizontalMovement * _speed * Time.deltaTime, 0f, 0f);
        transform.position = transform.position + movement;
        FlipSprite(movement);
    }

    private void ApplyGravity(float gravityScale, float fallingGravityScale)
    {
        if (_rigidbody.velocity.y >= 0)
            _rigidbody.gravityScale = gravityScale;
        else if (_rigidbody.velocity.y < 0)
            _rigidbody.gravityScale = fallingGravityScale;
    }

    private void Jump(float jumpForce)
    {
        _animator.SetTrigger("Jump");
        PlayDust();
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpForce);
    }

    private void FlipSprite(Vector3 direction)
    {
        if (direction.x > 0)
            _renderer.flipX = false;

        if (direction.x < 0)
            _renderer.flipX = true;
    }

    private void PlayDust()
    {
        _dustParticle.Play();
    }
}
