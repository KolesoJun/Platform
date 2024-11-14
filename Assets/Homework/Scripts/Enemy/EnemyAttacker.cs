using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private int _damage;
    [SerializeField] private EnemyMover _mover;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerHealth player))
        {
            player.TakeDamage(_damage);
            Kick(player);
        }
    }

    private void Kick(Health player)
    {
        if (player.gameObject.TryGetComponent(out Rigidbody2D rigidbody))
        {
            float directionKick = _mover.Direction * -1f;
            rigidbody.AddForce(player.gameObject.transform.right * _force * directionKick);
        }
    }
}
