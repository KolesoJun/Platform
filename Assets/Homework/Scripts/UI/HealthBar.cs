using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private float _step;
    [SerializeField] private Image _imageFill;
    [SerializeField] private Health _health;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        _health.ChangedCountCurrent += View;
    }

    private void LateUpdate()
    {
        transform.rotation = Quaternion.identity;
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
        
        while (_imageFill.fillAmount != targetPercent)
        {
            _imageFill.fillAmount = Mathf.MoveTowards(_imageFill.fillAmount, targetPercent, _step);
            yield return wait;
        }
    }

    private float CalculatePercent(float value)
    {
        return value / _health.CountMax;
    }

    private void Off()
    {
        gameObject.SetActive(false);
    }
}
