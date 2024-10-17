using UnityEngine;

public class EnemyHealth : HealthHandler
{
    private Vector2 _scaleDefault;
    private float _cutBack = 1.5f;

    private void Start()
    {
        _scaleDefault = transform.localScale;
    }

    public override void TakeDamage(int damage)
    {
        transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y / _cutBack);
        base.TakeDamage(damage);

        if (HealthCurrent > 0)
            transform.localScale = _scaleDefault;
    }
}
