using UnityEngine;
using System;

[RequireComponent(typeof(AudioClip))]

public class Coin : MonoBehaviour
{
    [SerializeField] private AudioClip _pickupSound;
    
    public event Action<int> Collected;

    private int _score = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            AudioSource.PlayClipAtPoint(_pickupSound, transform.position);
            Collected?.Invoke(_score);
            Destroy(gameObject);
        }
    }
}