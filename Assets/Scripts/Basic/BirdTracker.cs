using UnityEngine;

public class BirdTracker : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private float _xOffset = 1;

    private void Update()
    {
        Follow();
    }

    private void Follow()
    {
        Vector3 position = transform.position;
        position.x = _bird.transform.position.x + _xOffset;
        transform.position = position;
    }
}