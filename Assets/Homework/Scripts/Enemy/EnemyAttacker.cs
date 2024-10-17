using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private int _damage;

    private EnemyMover _mover;

    private void Awake()
    {
        _mover = GetComponent<EnemyMover>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerHealth player))
        {
            Kick(player);
            player.TakeDamage(_damage);
        }
    }

    private void Kick(PlayerHealth player)
    {
        if (player.gameObject.TryGetComponent(out Rigidbody2D rigidbody))
            rigidbody.AddForce(player.gameObject.transform.right * _force * _mover.Direction);
    }
}
