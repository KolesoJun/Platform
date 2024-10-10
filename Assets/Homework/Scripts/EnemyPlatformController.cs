using System;
using UnityEngine;

public class EnemyPlatformController : MonoBehaviour
{
    private RaycastHit2D _ray;
    private float _lengthRay = 5f;
    private float _directionDown = -1f;

    public event Action LeavedPlatform;

    private void Update()
    {
        DrawRay();
    }

    private void DrawRay()
    {
        _ray = Physics2D.Raycast(transform.position, transform.up * _directionDown * _lengthRay);

        if (_ray == false)
            LeavedPlatform?.Invoke();
    }
}
