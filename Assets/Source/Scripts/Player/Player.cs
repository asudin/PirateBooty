using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Coin _coin;

    private int _walletPlayer = 0;
    private void OnEnable() => _coin.Collected += ChangeCountWallet;

    private void OnDisable() => _coin.Collected -= ChangeCountWallet;

    private void ChangeCountWallet(int score)
    {
        _walletPlayer += score;
    }
}