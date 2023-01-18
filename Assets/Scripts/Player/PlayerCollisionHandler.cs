using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] private float _collisionShakeDuration;
    [SerializeField] private ScreenShake _shaker;

    private Player _player;

    private void OnEnable()
    {
        _shaker.Registered += OnScreenShakeRegistered;
    }

    private void OnDisable()
    {
        _shaker.Registered -= OnScreenShakeRegistered;
    }

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void OnScreenShakeRegistered()
    {
        _shaker = ServiceLocator.Get<ScreenShake>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Enemy enemy))
        {
            _shaker.Shake(_collisionShakeDuration);
            _player.Die();
        }

        if (collision.collider.TryGetComponent(out Pit pit))
        {
            _shaker.Shake(_collisionShakeDuration);
            _player.Die();
        }
    }
}
