using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class VampirismBar : MonoBehaviour
{
    [SerializeField] private AbylityVampir _abylity;
    [SerializeField] private Image _imageFill;
    [SerializeField] private float _delay;
    [SerializeField] private float _step;

    private Coroutine _coroutine;

    private void Awake()
    {
        Off();
    }

    private void OnEnable()
    {
        _abylity.CanDrawed += View;
    }

    private void LateUpdate()
    {
        transform.rotation = Quaternion.identity;
    }

    private void OnDisable()
    {
        _abylity.CanDrawed -= View;
    }

    private void View(bool isWork)
    {
        _imageFill.enabled = true;
        float target;
        float time;

        if (isWork)
        {
            target = 0f;
            time = _abylity.TimeWorking;
        }
        else
        {
            target = 1f;
            time = _abylity.TimeRecharge;
        }

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Edit(target, time));
    }

    private IEnumerator Edit(float target, float time)
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);
        _step = 1f / time;

        while (time > 0)
        {
            _imageFill.fillAmount = Mathf.MoveTowards(_imageFill.fillAmount, target, _step);
            time--;
            yield return wait;
        }

        Off();
    }

    private void Off()
    {
        _imageFill.enabled = false;
    }
}
