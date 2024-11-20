using UnityEngine;

public class TargetHandler : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _radius;

    public EnemyHealth Search()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_player.transform.position, _radius);

        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent(out EnemyHealth enemy))
                return enemy;
        }

        return null;
    }
}
