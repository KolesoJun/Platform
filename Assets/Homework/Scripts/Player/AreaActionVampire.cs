using System;
using UnityEngine;

public class AreaActionVampire : MonoBehaviour
{
    [SerializeField] private AbylityVampir _abylity;
    [SerializeField] private SpriteRenderer _image;

    public event Action<EnemyHealth> DetectedTarget;

    private void Awake()
    {
        _image.enabled = false;
    }

    private void OnEnable()
    {
        _abylity.Enabled += Draw;
    }

    private void OnDisable()
    {
        _abylity.Enabled -= Draw;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyHealth enemy))
            DetectedTarget?.Invoke(enemy);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyHealth enemy))
            DetectedTarget?.Invoke(null);
    }

    private void Draw(bool enable)
    {
        _image.enabled = enable;
    }
}
