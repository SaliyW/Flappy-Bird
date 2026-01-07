using UnityEngine;
using UnityEngine.Events;

public class BirdScoreCounter : MonoBehaviour
{
    private int _score = 0;
    private int _bestScore = 0;

    public event UnityAction<int> ScoreChanged;
    public event UnityAction<int> BestScoreChanged;

    public void Add()
    {
        _score++;

        if (_score > _bestScore)
        {
            _bestScore = _score;

            BestScoreChanged?.Invoke(_bestScore);
        }

        ScoreChanged?.Invoke(_score);
    }

    public void Reset()
    {
        _score = 0;
        ScoreChanged?.Invoke(_score);
    }
}