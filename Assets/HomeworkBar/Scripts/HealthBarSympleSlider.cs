using UnityEngine;
using UnityEngine.UI;

public class HealthBarSympleSlider : HealthBar
{
    protected override void View(float health)
    {
        Slider.value = CalculatePercent(health);
    }
}
