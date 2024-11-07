using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private PlayerHealth _health;
    [SerializeField] private float _delay;
    [SerializeField] private float _step;

    WaitForSeconds _wait;
    private Coroutine _coroutine;
    private float _percent = 100f;

    private void Awake()
    {
        _slider.maxValue = _percent;
        _wait = new WaitForSeconds(_delay);
    }

    private void OnEnable()
    {
        _health.ChangedCurrentHealth += View;
        _health.Teated += View;
    }

    private void OnDisable()
    {
        _health.ChangedCurrentHealth -= View;
        _health.Teated -= View;
    }

    private void View(float health)
    {
        float targetPercent = health * _percent / _health.HealthMax;

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Edit(targetPercent));
    }

    private IEnumerator Edit(float targetPercent)
    {
        while (_slider.value != targetPercent)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, targetPercent, _step);
            yield return _wait;
        }
    }
}
