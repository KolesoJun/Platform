using System;

public class PlayerHealth : HealthHandler
{
    public event Action<float> Teated;

    public void ReplenishHealth(float countHealth)
    {
        if (HealthCurrent + countHealth < HealthMax)
            HealthCurrent += countHealth;
        else
            HealthCurrent = HealthMax;

        Teated?.Invoke(HealthCurrent);
    }
}
