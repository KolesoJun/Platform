using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
public class Enemy : MonoBehaviour
{
    private EnemyMover _enemyMover;

    private void Awake()
    {
        _enemyMover = GetComponent<EnemyMover>();
    }

    private void FixedUpdate()
    {
        _enemyMover.Move();
    }
}
