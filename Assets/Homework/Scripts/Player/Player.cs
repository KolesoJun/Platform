using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private PlayerAnimator _playerAnimator;
    [SerializeField] private PlayerHealth _health;

    private void OnEnable()
    {
        _health.Died += GameOver;
        _inputReader.Jumped += Jump;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnDisable()
    {
        _health.Died -= GameOver;
        _inputReader.Jumped -= Jump;
    }

    private void GameOver()
    {
        Destroy(gameObject);
    }

    private void Move()
    {
        if (_inputReader.Direction != 0)
        {
            _mover.Rotate(_inputReader.Direction);
            _mover.Move(_inputReader.Direction);
        }

        _playerAnimator.PlayAnimMove(_inputReader.Direction);
    }

    private void Jump()
    {
        if (_groundDetector.IsMovedOnGround)
        {
            _mover.Jump();
            _playerAnimator.PlayAnimJump();
        }
    }
}
