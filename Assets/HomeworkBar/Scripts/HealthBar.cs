using UnityEngine;
using UnityEngine.UI;

public abstract class HealthBar : MonoBehaviour
{
    [SerializeField] protected Slider Slider;
    [SerializeField] protected PlayerHealth Health;

    protected float Percent = 100f;

    private void Awake()
    {
        if(Slider != null)
            Slider.maxValue = Percent;
    }

    private void OnEnable()
    {
        Health.ChangedCurrentHealth += View;
        Health.Teated += View;
    }

    private void OnDisable()
    {
        Health.ChangedCurrentHealth -= View;
        Health.Teated -= View;
    }

    protected abstract void View(float value);

    protected float CalculatePercent(float value)
    {
        return value * Percent / Health.HealthMax;
    }
}
