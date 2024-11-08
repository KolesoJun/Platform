using UnityEngine;

public class EnemyHealth : Health
{
    private Vector2 _scaleDefault;
    private float _cutBack = 1.5f;

    private void Start()
    {
        _scaleDefault = transform.localScale;
    }

    public override void TakeDamage(float damage)
    {
        transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y / _cutBack);
        base.TakeDamage(damage);

        if (CountCurrent > 0)
            transform.localScale = _scaleDefault;
    }
}
