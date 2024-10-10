using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private EnemyPlatformController _platformController;
    private float _angleRotate;

    private void Awake()
    {
        _platformController = GetComponentInChildren<EnemyPlatformController>();
    }

    private void OnEnable()
    {
        _platformController.LeavedPlatform += Rotate;
    }

    private void OnDisable()
    {
        _platformController.LeavedPlatform -= Rotate;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }

    private void Rotate()
    {
        transform.rotation = Quaternion.Euler(0f, CalculateAngleRotate(), 0f);
    }

    private float CalculateAngleRotate()
    {
        float angleMax = 180f;

        if (_angleRotate >= angleMax)
            return _angleRotate -= angleMax;
        else
            return _angleRotate += angleMax;
    }
}
