using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]

public class WaypointMovement : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private Transform[] _points;
    private SpriteRenderer _renderer;
    private Animator _animator;
    private int _currentPoint = 0;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    private void Update()
    {
        Transform target = _points[_currentPoint];
        _animator.SetFloat("Speed", Mathf.Abs(_speed));
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        var enemyDeltaPathPosition = target.position.x - transform.position.x;

        if (transform.position == target.position)
        {
            _currentPoint++;

            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }

        if (enemyDeltaPathPosition > 0)
        _renderer.flipX = false;

        if (enemyDeltaPathPosition < 0)
            _renderer.flipX = true;
    }
}
