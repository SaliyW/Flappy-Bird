using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreDisplay;
    [SerializeField] private TextMeshProUGUI _bestScoreDisplay;

    public void UpdateScoreDisplay(int score)
    {
        _scoreDisplay.text = $"Score: {score}";
    }

    public void UpdateBestScoreDisplay(int bestScore)
    {
        _bestScoreDisplay.text = $"Best score: {bestScore}";
    }

    public void ToggleVisibilityBestScoreDisplay()
    {
        int minAlpha = 0;
        int maxAlpha = 1;

        _bestScoreDisplay.alpha = _bestScoreDisplay.alpha > minAlpha ? minAlpha : maxAlpha;
    }
}