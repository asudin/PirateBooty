using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;

    [Header("UI Screens")]
    [SerializeField] private GameOverScreen _gameOverScreen;

    [Header("Spawners")]
    [SerializeField] private PlayerSpawner _playerSpawner;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private CrateSpawner _crateSpawner;

    private bool _isGameOver = false;

    private void OnEnable()
    {
        _player.GameOver += OnGameOver;
        _gameOverScreen.ShowCanvas += OnRestartGame;
    }

    private void OnDisable()
    {
        _player.GameOver -= OnGameOver;
        _gameOverScreen.ShowCanvas -= OnRestartGame;
    }
    private void Update()
    {
        if (_isGameOver)
            RestartGame();
    }


    private void OnRestartGame()
    {
        _isGameOver = true;
    }

    private void RestartGame()
    {
        if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void OnGameOver()
    {
        _gameOverScreen.Open();
        _gameOverScreen.ShowFinalScore();
    }
}
