using UnityEngine;

[RequireComponent(typeof(Animator), typeof(SpriteRenderer), typeof(Rigidbody2D))]

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private ParticleSystem _dustParticle;

    private Animator _animator;
    private SpriteRenderer _renderer;
    private Rigidbody2D _rigidbody;
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
        Jump();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _groundDetector.IsGrounded)
        {
            _animator.SetTrigger("Jump");
            PlayDust();
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
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
