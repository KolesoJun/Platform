using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private EnemyPlatformDetector _platformDetector;

    private float _angleRotate;

    private void OnEnable()
    {
        _platformDetector.LeavedPlatform += Rotate;
    }

    private void OnDisable()
    {
        _platformDetector.LeavedPlatform -= Rotate;
    }

    public void Move()
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
