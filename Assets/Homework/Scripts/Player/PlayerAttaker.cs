using UnityEngine;

public class PlayerAttaker : MonoBehaviour
{
    private const float Force = 200f;

    [SerializeField] private int _damage;
    [SerializeField] private Rigidbody2D _rigidbody;

    private bool _canAttack = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyHealth enemy))
        {
            enemy.TakeDamage(_damage);
            _rigidbody.AddForce(Vector2.up * Force);
            _canAttack = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyHealth>(out _))
        {
            _canAttack = true;
        }
    }
}
