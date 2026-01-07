using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BirdAnimations : MonoBehaviour
{
    private const string Jump = nameof(Jump);

    private Animator _animator;
    private int _jumpHash;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _jumpHash = Animator.StringToHash(Jump);
    }

    public void SetJump()
    {
        _animator.SetTrigger(_jumpHash);
    }
}