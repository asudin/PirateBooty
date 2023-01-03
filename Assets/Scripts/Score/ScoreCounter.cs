using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _score;
    [SerializeField] private CrateSpawner _spawner;

    private static int _playerScore = 0;

    private void OnEnable()
    {
        _spawner.Collected += ChangeScoreNumber;
    }

    private void OnDisable()
    {
        _spawner.Collected -= ChangeScoreNumber;
    }

    private void Update()
    {
        _score.text = _playerScore.ToString();
    }

    private void ChangeScoreNumber(List<Crate> crates)
    {
        foreach (Crate crate in crates)
            _playerScore += crate.Score;
    }
}
