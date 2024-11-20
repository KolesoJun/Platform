using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BarVampyre : MonoBehaviour
{
    [SerializeField] private TimerVampyre _timerVampyre;
    [SerializeField] private Image _imageBar;
    [SerializeField] private float _step;

    private Coroutine _coroutine;

    private void Awake()
    {
        Off();
    }

    private void OnEnable()
    {
        _timerVampyre.Activated += On;
        _timerVampyre.Worked += Activation;
        _timerVampyre.DeactivatedBar += Off;
    }

    private void LateUpdate()
    {
        transform.rotation = Quaternion.identity;
    }

    private void OnDisable()
    {
        _timerVampyre.Activated -= On;
        _timerVampyre.Worked -= Activation;
        _timerVampyre.DeactivatedBar -= Off;
    }

    private void Activation(float target, float valueMax)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Work(target, valueMax));
    }

    private IEnumerator Work(float target, float valueMax)
    {
        float targetPercent = target / valueMax;

        while (_imageBar.fillAmount != targetPercent)
        {
            _imageBar.fillAmount = Mathf.MoveTowards(_imageBar.fillAmount, targetPercent, _step);
            yield return null;
        }
    }

    private void On()
    {
        _imageBar.enabled = true;
    }

    private void Off()
    {
        _imageBar.enabled = false;
    }
}