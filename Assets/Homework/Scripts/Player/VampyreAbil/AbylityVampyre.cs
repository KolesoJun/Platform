using System;
using System.Collections;
using UnityEngine;

public class AbylityVampyre : MonoBehaviour
{
    private const float Percent = 100f;

    [SerializeField] private TargetHandler _targetsHandler;
    [SerializeField] private PlayerHealth _health;
    [SerializeField] private TimerVampyre _timerVampyre;
    [SerializeField] private float _percentHealthTakeover;

    private Coroutine _coroutine;
    private bool _isWork;

    private void OnEnable()
    {
        _timerVampyre.Activated += Activate;
        _timerVampyre.Deactivated += Off;
    }

    private void OnDisable()
    {
        _timerVampyre.Activated -= Activate;
        _timerVampyre.Deactivated -= Off;
    }

    private void Activate()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Work());
    }

    private IEnumerator Work()
    {
        float delay = 0.01f;
        WaitForSeconds wait = new WaitForSeconds(delay);
        _isWork = true;

        while (_isWork)
        {
            EnemyHealth target = _targetsHandler.Search();

            if (target != null)
            {
                float healthTakeover = (_percentHealthTakeover * target.CountMax) / Percent;

                if (target.CountCurrent > healthTakeover)
                    _health.Replenish(healthTakeover);
                else
                    _health.Replenish(target.CountCurrent);

                target.TakeDamage(healthTakeover);
            }

            yield return wait;
        }
    }

    private void Off()
    {
        _isWork = false;
        //StopCoroutine(_coroutine);
    }
}
