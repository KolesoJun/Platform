using UnityEngine;
using UnityEngine.UI;

public abstract class HealthBar : MonoBehaviour
{
    protected const float Percent = 100f;

    [SerializeField] protected Slider Slider;
    [SerializeField] protected Health Health;

    private void Awake()
    {
        Slider.maxValue = Percent;
    }

    private void OnEnable()
    {
        Health.ChangedCountCurrent += View;
    }

    private void OnDisable()
    {
        Health.ChangedCountCurrent -= View;
    }

    protected abstract void View(float value);

    protected float CalculatePercent(float value)
    {
        return value * Percent / Health.CountMax;
    }
}
