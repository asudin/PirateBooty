using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private PlayerSpawner _playerSpawner;

    private Player _player;

    private void Awake()
    {
        //_player = ServiceLocator.Get<Player>();
    }

    private void OnEnable()
    {
        _player.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _player.GameOver -= OnGameOver;
    }

    private void Update()
    {
        if (_playerSpawner.IsPlayerInstantiated)
        {
            if (ServiceLocator.Get<Player>() != null)
            {
                Debug.Log($"RRRRRR = TRUE");
                _player = ServiceLocator.Get<Player>();
            }
        }

        Debug.Log($"IS: {_player}");
        Debug.Log($"Registered?: {ServiceLocator.Get<Player>()}");
    }

    private void OnRestartGameButtonsClick()
    {
        _gameOverScreen.Close();
        StartGame();
    }

    private void StartGame()
    {
        _player.ResetPlayer();
    }

    public void OnGameOver()
    {
        _gameOverScreen.Open();
    }
}
