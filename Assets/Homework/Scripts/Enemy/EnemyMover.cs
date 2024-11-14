using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private Enemy _enemy;
    
    private float _directionRight = 1f;
    private float _directionLeft = -1f;
    
    public float Direction { get; private set; }

    private void Start()
    {
        Direction = _directionRight;
    }

    public void Patrol()
    {
        if (_groundDetector.IsMovedOnGround)
            _enemy.transform.Translate(_enemy.transform.right * Direction * _speed * Time.deltaTime);
        else
            Rotate();
    }

    public void Pursue(Player player)
    {
        if (_groundDetector.IsMovedOnGround)
            _enemy.transform.position = Vector2.MoveTowards(_enemy.transform.position, player.transform.position, _speed * Time.deltaTime);
        else
            Rotate();
    }

    public void SelectDirection(Player player)
    {
        if (player != null)
        {
            if (player.transform.position.x >= _enemy.transform.position.x)
                Direction = _directionLeft;
            else
                Direction = _directionRight;

            Rotate();
        }
    }

    private void Rotate()
    {
        float angleLeft = 180f;
        Direction *= _directionLeft;

        if (Direction >= 0f)
            _enemy.transform.rotation = new Quaternion();
        else
            _enemy.transform.rotation = Quaternion.Euler(0f, angleLeft, 0f);
    }
}
