using System;
using UnityEngine;

public class AreaActionVampire : MonoBehaviour
{
    public event Action<EnemyHealth> DetectedTarget;
    public event Action<EnemyHealth> LeavedTarget;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyHealth enemy))
            DetectedTarget?.Invoke(enemy);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyHealth enemy))
            DetectedTarget?.Invoke(enemy);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyHealth enemy))
            LeavedTarget?.Invoke(null);
    }
}
