using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private ObstacleSpawner _spawner;
    [SerializeField] private Window _startWindow;
    [SerializeField] private Window _endWindow;
    [SerializeField] private ScoreView _scoreView;

    private void Start()
    {
        Time.timeScale = 0;

        _startWindow.Open();
        _endWindow.Close();
    }

    private void OnEnable()
    {
        _startWindow.ButtonClicked += OnPlayButtonClick;
        _endWindow.ButtonClicked += OnRestartButtonClick;
        _bird.Collided += FinishGame;
    }

    private void OnDisable()
    {
        _startWindow.ButtonClicked -= OnPlayButtonClick;
        _endWindow.ButtonClicked -= OnRestartButtonClick;
        _bird.Collided -= FinishGame;
    }

    private void FinishGame()
    {
        Time.timeScale = 0;

        _endWindow.Open();
        _scoreView.ToggleVisibilityBestScoreDisplay();
    }

    private void StartGame()
    {
        Time.timeScale = 1;

        _scoreView.ToggleVisibilityBestScoreDisplay();
    }

    private void OnRestartButtonClick()
    {
        _bird.Reset();
        _spawner.Reset();
        _endWindow.Close();

        StartGame();
    }

    private void OnPlayButtonClick()
    {
        _startWindow.Close();

        StartGame();
    }
}