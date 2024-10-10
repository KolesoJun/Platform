using UnityEngine;

[RequireComponent(typeof(InputReader), typeof(PlayerMover), typeof(GroundDetector))]
public class Player : MonoBehaviour
{
    private InputReader _inputReader;
    private PlayerMover _mover;
    private GroundDetector _groundDetector;
    private int _coins;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _mover = GetComponent<PlayerMover>();
        _groundDetector = GetComponent<GroundDetector>();
    }

    private void FixedUpdate()
    {
        if (_inputReader.Direction != 0)
        {
            _mover.Rotate(_inputReader.Direction);
            _mover.Move(_inputReader.Direction);
        }

        if (_inputReader.GetIsJump() && _groundDetector.IsGround)
            _mover.Jump();
    }

    public void AddCoin(int value)
    {
        _coins += value;
        Debug.Log(_coins);
    }
}
