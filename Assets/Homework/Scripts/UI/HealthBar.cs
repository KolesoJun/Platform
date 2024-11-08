using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private const float Percent = 100f;

    [SerializeField] private float _delay;
    [SerializeField] private float _step;
    [SerializeField] private Slider _slider;
    [SerializeField] private Health _health;

    private Coroutine _coroutine;

    private void Awake()
    {
        _slider.maxValue = Percent;
        _slider.value = Percent;
    }

    private void OnEnable()
    {
        _health.ChangedCountCurrent += View;
    }

    private void OnDisable()
    {
        _health.ChangedCountCurrent -= View;
    }

    private void View(float health)
    {
        float targetPercent = CalculatePercent(health);

        if (targetPercent <= 0)
        {
            Off();
            return;
        }

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Edit(targetPercent));
    }

    private IEnumerator Edit(float targetPercent)
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);

        while (_slider.value != targetPercent)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, targetPercent, _step);
            yield return wait;
        }
    }

    private float CalculatePercent(float value)
    {
        return value * Percent / _health.CountMax;
    }

    private void Off()
    {
        gameObject.SetActive(false);
    }
}
