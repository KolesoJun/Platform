using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    private const string AxisHorizontal = "Horizontal";

    [SerializeField] private float _speed;
    [SerializeField] private float _force;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private float _direction;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        Rotate();
        Jump();
    }

    private void Move()
    {
        _direction = Input.GetAxis(AxisHorizontal) * _speed * Time.deltaTime;
        _animator.SetFloat(PlayerAnimator.Speed, Mathf.Abs(_direction));
        transform.Translate(transform.right * _direction);
    }

    private void Rotate()
    {
        float angleLeft = 180f;

        if (_direction >= 0f)
            transform.rotation = new Quaternion();
        else
            transform.rotation = Quaternion.Euler(0f, angleLeft, 0f);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(Vector2.up * _force);
            _animator.SetTrigger(PlayerAnimator.IsJump);
        }
    }
}
