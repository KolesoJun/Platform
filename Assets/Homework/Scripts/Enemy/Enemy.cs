using UnityEngine;

[RequireComponent(typeof(EnemyHealth))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private PlayerDetector _determinantPlayer;
    [SerializeField] private EnemyMover _mover;
    [SerializeField] private float _timeLifeForDie;

    private EnemyHealth _health;
    private Player _target;

    private void Awake()
    {
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
