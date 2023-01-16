using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _score;
    [SerializeField] private Player _player;
    [SerializeField] private CrateSpawner _spawner;

    private static int _playerScore = 0;
    private static int _bestScore = 0;

    public int BestScore => _bestScore;

    private void OnEnable()
    {
        _spawner.Collected += ChangeScoreNumber;
        _player.GameOver += ResetScore;
    }

    private void OnDisable()
    {
        _spawner.Collected -= ChangeScoreNumber;
        _player.GameOver -= ResetScore;
    }

    private void Update()
    {
        _score.text = _playerScore.ToString();
        UpdateBestScore();
    }

    private void ChangeScoreNumber(Crate crate)
    {
        _playerScore += crate.Score;
    }

    private void UpdateBestScore()
    {
        if (_playerScore > _bestScore)
            _bestScore = _playerScore;
    }

    private void ResetScore()
    {
        _playerScore = 0;
    }
}
