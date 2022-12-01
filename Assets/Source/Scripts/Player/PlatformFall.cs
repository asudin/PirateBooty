using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class PlatformFall : MonoBehaviour
{
    private BoxCollider2D _playerCollider;
    private Platform _currentOneWayPlatform;

    private void Awake()
    {
        _playerCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        var jumpingDownKeyboard = Input.GetKey(KeyCode.S);
        var jumpingDownArrow = Input.GetKey(KeyCode.DownArrow);

        if (Input.GetKeyDown(KeyCode.Space) || jumpingDownKeyboard || jumpingDownArrow)
        {
            if (_currentOneWayPlatform != null)
                StartCoroutine(DisableCollision());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Platform>(out Platform platform))
            _currentOneWayPlatform = platform;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Platform>(out Platform platform))
            _currentOneWayPlatform = null;
    }

    private IEnumerator DisableCollision()
    {
        var fallTime = 0.4f;
        BoxCollider2D platformCollider = _currentOneWayPlatform.GetComponent<BoxCollider2D>();

        Physics2D.IgnoreCollision(_playerCollider, platformCollider);
        yield return new WaitForSeconds(fallTime);
        Physics2D.IgnoreCollision(_playerCollider, platformCollider, false);
    }
}
