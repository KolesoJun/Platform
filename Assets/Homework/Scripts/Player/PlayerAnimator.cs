using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator: MonoBehaviour
{
    public static readonly int Speed = Animator.StringToHash(nameof(Speed));
    public static readonly int IsJump = Animator.StringToHash(nameof(IsJump));

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayAnimMove(float direction) => _animator.SetFloat(PlayerAnimator.Speed, Mathf.Abs(direction));

    public void PlayAnimJump() => _animator.SetTrigger(PlayerAnimator.IsJump);
}
