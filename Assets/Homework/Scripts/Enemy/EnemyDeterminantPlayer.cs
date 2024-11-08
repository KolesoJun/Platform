using System;
using UnityEngine;

public class EnemyDeterminantPlayer : MonoBehaviour
{
    public event Action<Player> Detected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
            Detected?.Invoke(player);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
            Detected?.Invoke(null);
    }
}
