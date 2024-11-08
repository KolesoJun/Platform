using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GroundDetector _groubdDetector;
    
    private float _directionRight = 1f;
    private float _directionLeft = -1f;
    
    public float Direction { get; private set; }

    private void OnEnable()
    {
        _groubdDetector.LeavedGround += Rotate;
    }

    private void Start()
    {
        Direction = _directionRight;
    }

    private void OnDisable()
    {
        _groubdDetector.LeavedGround -= Rotate;
    }

    public void Patrol()
    {
        transform.Translate(transform.right * Direction * _speed * Time.deltaTime);
    }

    public void Pursue(Player player)
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, _speed * Time.deltaTime);
    }

    public void SelectDirection(Player player)
    {
        if (player != null)
        {
            if (player.transform.position.x >= transform.position.x)
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
            transform.rotation = new Quaternion();
        else
            transform.rotation = Quaternion.Euler(0f, angleLeft, 0f);
    }
}
