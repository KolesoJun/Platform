using UnityEngine;

public class PlayerAttaker : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyHealth enemy))
        {
            enemy.TakeDamage(_damage);
        }
    }
}
