using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(Enemy))]
public class MoveState : State
{
    private float _directionX = -1f;
    private float _speed;
    private bool _isFacingRight = false;
    private Enemy _enemy;
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private Vector3 _localScale;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _enemy = GetComponent<Enemy>();
        _speed = _enemy.EnemyData.Speed;
        _localScale = transform.localScale;
    }

    private void FixedUpdate()
    {
        _animator.SetFloat("Speed", Mathf.Abs(_speed));
        _rigidbody.velocity = new Vector2(_directionX * _speed, _rigidbody.velocity.y);
    }

    private void LateUpdate()
    {
        CheckWhereToFace(ref _isFacingRight, _localScale);
    }

    private void CheckWhereToFace(ref bool isFacingDirection, Vector3 localScale)
    {
        if (_directionX > 0)
            isFacingDirection = true;
        else if (_directionX < 0)
            isFacingDirection = false;

        var xAxisDirection = -1f;
        if ((isFacingDirection && localScale.x < 0) || (!isFacingDirection && localScale.x > 0))
            localScale.x *= xAxisDirection;

        transform.localScale = localScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var xAxisDirection = -1f;
        if (collision.GetComponent<Wall>())
            _directionX *= xAxisDirection;
    }
}
