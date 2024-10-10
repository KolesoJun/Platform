using System;
using UnityEngine;

public class EnemyPlatformDetector : MonoBehaviour
{
    public event Action LeavedPlatform;

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out _))
            LeavedPlatform?.Invoke();
    }
}
