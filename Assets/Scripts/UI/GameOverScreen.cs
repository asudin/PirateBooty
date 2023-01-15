using System;
using TMPro;
using UnityEngine;

public class GameOverScreen : Screen
{
    [SerializeField, Tooltip("Higher positive value equals faster fade in/out animation.")] private float _time;

    [Header("Final Score")]
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private TMP_Text _bestScore;

    public event Action ShowCanvas;

    public override void Close()
    {
        CanvasGroup.InstantClose();
    }

    public override void Open()
    {
        ShowCanvas?.Invoke();
        StartCoroutine(CanvasGroup.FadeIn(_time));
    }

    public void ShowFinalScore()
    {
        var bestScoreText = "Best: ";
        _bestScore.text = bestScoreText + _scoreCounter.BestScore.ToString();
    }
}
