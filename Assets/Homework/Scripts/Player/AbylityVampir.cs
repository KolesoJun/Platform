using System;
using System.Collections;
using UnityEngine;

public class AbylityVampir : MonoBehaviour
{
    [SerializeField] private AreaActionVampire _area;
    [SerializeField] private PlayerHealth _health;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private float _healthTakeover;
    [SerializeField] private float _timeRecharge;
    [SerializeField] public float _timeWorking;

    private Coroutine _coroutine;
    private EnemyHealth _target;
    private float _delay = 1f;
    private bool _isWork;

    public event Action<bool> Enabled;

    private void OnEnable()
    {
        _inputReader.ActivatedVampirism += Activate;
        _area.DetectedTarget += SelectTarget;
    }

    private void OnDisable()
    {
        _inputReader.ActivatedVampirism -= Activate;
        _area.DetectedTarget -= SelectTarget;
    }

    private void Activate()
    {
        if (_isWork == false)
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(Work());
            _isWork = true;
            Enabled?.Invoke(_isWork);
        }
    }

    private IEnumerator Work()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);
        float remainsTime = _timeWorking;

        while (remainsTime > 0)
        {
            if (_target != null)
            {
                _target.TakeDamage(_healthTakeover);
                _health.Replenish(_healthTakeover);
            }
            
            remainsTime--;
            yield return wait;
        }

        wait = new WaitForSeconds(_timeRecharge);
        Enabled?.Invoke(false);
        yield return wait;
        _isWork = false;
    }

    private void SelectTarget(EnemyHealth enemy)
    {
        if (enemy != null)
            _target = enemy;
        else
            _target = null;
    }
}
