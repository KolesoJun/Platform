using System;
using System.Collections;
using UnityEngine;

public class TimerVampyre : MonoBehaviour
{
    [SerializeField] private float _timeRecharge;
    [SerializeField] private float _timeWorking;
    [SerializeField] private InputReader _input;

    private Coroutine _coroutine;
    private bool _isWork;
    private float _delay = 1f;

    public event Action Activated;
    public event Action<float, float> Worked;
    public event Action Deactivated;
    public event Action DeactivatedBar;

    private void OnEnable()
    {
        _input.ActivatedVampirism += Activate;
    }

    private void OnDisable()
    {
        _input.ActivatedVampirism -= Activate;
    }

    private void Activate()
    {
        if (_isWork == false)
        {
            _isWork = true;

            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(Work());
            Activated?.Invoke();
        }
    }

    private IEnumerator Work()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);
        float remainsTime = _timeWorking;

        while (remainsTime > 0)
        {
            remainsTime--;
            Worked?.Invoke(remainsTime, _timeWorking);
            yield return wait;
        }

        _coroutine = StartCoroutine(Recharge());
    }

    private IEnumerator Recharge()
    {
        Deactivated?.Invoke();
        WaitForSeconds wait = new WaitForSeconds(_delay);
        float remainsTime = 0;

        while (remainsTime < _timeRecharge)
        {
            remainsTime++;
            Worked?.Invoke(remainsTime, _timeRecharge);
            yield return wait;
        }

        DeactivatedBar?.Invoke();
        _isWork = false;
    }
}
