using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _force;

    private bool _isWatchingRight = true;
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move(float direction)
    {
        _animator.SetFloat(PlayerAnimator.Speed, Mathf.Abs(direction));
        transform.Translate(transform.right * direction * _speed * Time.deltaTime);
    }

    public void Rotate(float direction)
    {
        float angleLeft = 180f;

        if (direction >= 0f)
            transform.rotation = new Quaternion();
        else
            transform.rotation = Quaternion.Euler(0f, angleLeft, 0f);
    }

    public void Jump()
    {
        _rigidbody.AddForce(Vector2.up * _force);
        _animator.SetTrigger(PlayerAnimator.IsJump);
    }
}
