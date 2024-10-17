using UnityEngine;

[RequireComponent(typeof(InputReader), typeof(PlayerMover), typeof(GroundDetector))]
[RequireComponent(typeof(PlayerAnimator))]
public class Player : MonoBehaviour
{
    private InputReader _inputReader;
    private PlayerMover _mover;
    private GroundDetector _groundDetector;
    private PlayerAnimator _playerAnimator;
    private PlayerHealth _health;
    
    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _mover = GetComponent<PlayerMover>();
        _groundDetector = GetComponent<GroundDetector>();
        _playerAnimator = GetComponent<PlayerAnimator>();
        _health = GetComponent<PlayerHealth>();
    }

    private void OnEnable()
    {
        _health.Died += GameOver;
    }

    private void FixedUpdate()
    {
        if (_inputReader.Direction != 0)
        {
            _mover.Rotate(_inputReader.Direction);
            _mover.Move(_inputReader.Direction);
        }
        
        _playerAnimator.PlayAnimMove(_inputReader.Direction);

        if (_inputReader.GetIsJump() && _groundDetector.IsGround)
        {
            _mover.Jump();
            _playerAnimator.PlayAnimJump();
        }
    }

    private void OnDisable()
    {
        _health.Died -= GameOver;
    }

    private void GameOver()
    {
        Destroy(gameObject);
    }
}
