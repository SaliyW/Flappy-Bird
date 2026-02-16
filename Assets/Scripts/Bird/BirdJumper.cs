using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BirdInputReader))]
[RequireComponent(typeof(BirdAnimations))]
public class BirdJumper : MonoBehaviour
{
    [SerializeField] private float _tapForce = 6;
    [SerializeField] private float _speed = 2.5f;
    [SerializeField] private float _rotationSpeed = 1;
    [SerializeField] private float _maxRotationZ = 35;
    [SerializeField] private float _minRotationZ = -60;
    
    private BirdAnimations _animations;
    private Rigidbody2D _rigidbody;
    private BirdInputReader _inputReader;
    private Vector3 _startPosition;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _inputReader = GetComponent<BirdInputReader>();
        _animations = GetComponent<BirdAnimations>();

        _startPosition = transform.position;

        SetRotationLimits();
    }

    public void Reset()
    {
        transform.SetPositionAndRotation(_startPosition, Quaternion.identity);
        _rigidbody.linearVelocity = Vector2.zero;
    }

    public void TryJump()
    {
        if (_inputReader.IsJumpKeyDown())
        {
            _animations.SetJump();

            _rigidbody.linearVelocity = new Vector2(_speed, _tapForce);
            transform.rotation = _maxRotation;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    private void SetRotationLimits()
    {
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
    }
}