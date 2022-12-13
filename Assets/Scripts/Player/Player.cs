using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator), typeof(AudioSource))]
public class Player : MonoBehaviour
{
    [SerializeField] private Coin _coin;

    private int _walletPlayer = 0;
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _dieSound;

    private void OnEnable() => _coin.Collected += ChangeCountWallet;

    private void OnDisable() => _coin.Collected -= ChangeCountWallet;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _dieSound = GetComponent<AudioSource>();
    }

    private void ChangeCountWallet(int score)
    {
        _walletPlayer += score;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.TryGetComponent(out Enemy enemy))
        {
            Destroy(gameObject);
        }
    }

    //private IEnumerator Die()
    //{
    //    var waitTime = 0.5f;

    //    _animator.Play("Die");
    //    _dieSound.Play();

    //    yield return new WaitForSeconds(waitTime);
    //    Destroy(gameObject);
    //}
}