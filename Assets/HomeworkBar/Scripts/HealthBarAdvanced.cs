using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarAdvanced : HealthBar
{
    [SerializeField] private float _delay;
    [SerializeField] private float _step;

    private Coroutine _coroutine;
    
    protected override void View(float health)
    {
        float targetPercent = CalculatePercent(health);

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Edit(targetPercent));
    }

    private IEnumerator Edit(float targetPercent)
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);

        while (Slider.value != targetPercent)
        {
            Slider.value = Mathf.MoveTowards(Slider.value, targetPercent, _step);
            yield return wait;
        }
    }
}
