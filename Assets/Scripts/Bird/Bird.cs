using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BirdJumper))]
[RequireComponent(typeof(BirdInputReader))]
[RequireComponent(typeof(BirdScoreCounter))]
[RequireComponent(typeof(BirdCollisionHandler))]
[RequireComponent(typeof(BirdAnimations))]
public class Bird : MonoBehaviour
{
    [SerializeField] ScoreView _scoreView;

    private BirdJumper _jumper;
    private BirdScoreCounter _scoreCounter;
    private BirdCollisionHandler _collisionHandler;

    public event UnityAction Collided;

    private void Awake()
    {
        _jumper = GetComponent<BirdJumper>();
        _scoreCounter = GetComponent<BirdScoreCounter>();
        _collisionHandler = GetComponent<BirdCollisionHandler>();
    }

    private void Update()
    {
        _jumper.TryJump();
    }

    private void OnEnable()
    {
        _collisionHandler.CollisionDetected += ProcessCollision;
        _scoreCounter.ScoreChanged += _scoreView.UpdateScoreDisplay;
        _scoreCounter.BestScoreChanged += _scoreView.UpdateBestScoreDisplay;
    }

    private void OnDisable()
    {
        _collisionHandler.CollisionDetected -= ProcessCollision;
        _scoreCounter.ScoreChanged -= _scoreView.UpdateScoreDisplay;
        _scoreCounter.BestScoreChanged -= _scoreView.UpdateBestScoreDisplay;
    }

    public void Reset()
    {
        _scoreCounter.Reset();
        _jumper.Reset();
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable is Wall || interactable is Ground)
        {
            Collided?.Invoke();
        }
        else if (interactable is ScoreZone)
        {
            _scoreCounter.Add();
        }
    }
}