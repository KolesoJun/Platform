using UnityEngine;

[RequireComponent(typeof(EnemyMover), typeof(EnemyHealth))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyDeterminantPlayer _determinantPlayer;
    [SerializeField] private float _timeLifeForDie;

    private EnemyMover _mover;
    private EnemyHealth _health;
    private Player _target;

    private void Awake()
    {
        _mover = GetComponent<EnemyMover>();
        _health = GetComponent<EnemyHealth>();
    }

    private void OnEnable()
    {
        _determinantPlayer.Detected += AppointTarget;
       _health.Died += Die;
    }

    private void OnDisable()
    {
        _determinantPlayer.Detected -= AppointTarget;
        _health.Died -= Die;
    }

    private void FixedUpdate()
    {
        if (_target != null)
            _mover.Pursue(_target);
        else
            _mover.Patrol();
    }

    private void AppointTarget(Player player)
    {
        _target = player;

        if(player != null)
            _mover.SelectDirection(_target);
    }

    private void Die()
    {
         Destroy(gameObject, _timeLifeForDie);
    }
}
