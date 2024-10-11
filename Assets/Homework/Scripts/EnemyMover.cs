using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GroundDetector _groubdDetector;

    private float _angleRotate;

    public void Move()
    {
        if (_groubdDetector.IsGround)
            transform.Translate(Vector2.right * _speed * Time.deltaTime);
        else
            Rotate();
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
