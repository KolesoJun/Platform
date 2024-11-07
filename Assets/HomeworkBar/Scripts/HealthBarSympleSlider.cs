using UnityEngine;
using UnityEngine.UI;

public class HealthBarSympleSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private PlayerHealth _health;

    private float _percent = 100f;

    private void Awake()
    {
        _slider.maxValue = _percent;
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
        _slider.value = health * _percent / _health.HealthMax;
    }
}
