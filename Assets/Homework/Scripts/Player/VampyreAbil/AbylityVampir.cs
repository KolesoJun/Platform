using System;
using System.Collections;
using UnityEngine;

public class AbylityVampir : MonoBehaviour
{
    [SerializeField] private VampirismTargetsHandler _targetsHandler;
    [SerializeField] private PlayerHealth _health;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private float _healthTakeover;

    [field: SerializeField] public float TimeRecharge { get; private set; }
    [field: SerializeField] public float TimeWorking { get; private set; }

    private Coroutine _coroutine;
    private EnemyHealth _target;
    private float _delay = 1f;
    private bool _isWork;

    public event Action<bool> CanDrawed;

    private void OnEnable()
    {
        _inputReader.ActivatedVampirism += Activate;
    }

    private void OnDisable()
    {
        _inputReader.ActivatedVampirism -= Activate;
    }

    private void Activate()
    {
        if (_isWork == false)
        {
            _isWork = true;
            CanDrawed?.Invoke(_isWork);

            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(Work());
        }
    }

    private IEnumerator Work()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);
        float remainsTime = TimeWorking;
        
        while (remainsTime > 0)
        {
            _target = _targetsHandler.Get(_health);

            if (_target != null)
            {
                if(_target.CountCurrent > _healthTakeover)
                    _health.Replenish(_healthTakeover);
                else
                    _health.Replenish(_target.CountCurrent);

                _target.TakeDamage(_healthTakeover);
            }
            
            remainsTime--;
            yield return wait;
        }

        CanDrawed?.Invoke(false);
        _coroutine = StartCoroutine(Recharge());
    }

    private IEnumerator Recharge()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);
        float remainsTime = TimeRecharge;

        while (remainsTime > 0)
        {
            remainsTime--;
            yield return wait;
        }

        _isWork = false;
    }
}
