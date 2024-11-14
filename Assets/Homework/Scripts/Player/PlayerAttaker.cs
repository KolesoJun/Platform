using UnityEngine;

public class PlayerAttaker : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private PlayerMover _playerMover;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyHealth enemy))
        {
            enemy.TakeDamage(_damage);
        }
    }
}
