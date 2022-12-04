using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    [Header("Movement Configuration")]
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundCheckRadius = 0.05f;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _jumpForce = 6f;
    [SerializeField] private LayerMask _collisionMask;
    [SerializeField] private ParticleSystem _dustParticle;

    private static class AnimatorPlayerController { public static class Params { public const string Speed = nameof(Speed); } }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        var jumpInput = Input.GetButton("Jump");
        var jumpInputReleased = Input.GetButtonUp("Jump");
        const string Grounded = "isGrounded";

        Move(horizontalInput, _speed);

        if (jumpInput && IsGrounded())
            Jump(_jumpForce);

        if (jumpInputReleased && _rigidbody.velocity.y > 0)
            _rigidbody.velocity = new Vector2(-_rigidbody.velocity.x, 0);

        if (horizontalInput != 0)
        {
            _animator.SetBool(Grounded, IsGrounded());
            transform.localScale = new Vector3(Mathf.Sign(horizontalInput), 1, 1);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _collisionMask);
    }

    private void Move(float horizontalMovement, float speed)
    {
        _animator.SetFloat(AnimatorPlayerController.Params.Speed, Mathf.Abs(horizontalMovement));
        _rigidbody.velocity = new Vector2(horizontalMovement * speed, _rigidbody.velocity.y);
    }

    private void Jump(float jumpForce)
    {
        _animator.SetTrigger("Jump");
        PlayDust(_dustParticle);
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpForce);
    }

    private void PlayDust(ParticleSystem jumpParticles)
    {
        jumpParticles.Play();
    }
}
