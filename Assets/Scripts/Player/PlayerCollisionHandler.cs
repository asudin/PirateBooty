using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    private Player _player;

    private void Start()
    {
        _player = GetComponent<Player>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Enemy enemy))
        {
            _player.Die();
        }

        if (collision.gameObject.TryGetComponent(out Crate crate))
        {
            _player.ChangeWeapon(crate.GetRandomWeaponIndex());
            crate.gameObject.SetActive(false);
        }
    }
}
