using System;
using UnityEngine;

public class PlayerHealth : HealthHandler
{
    public void ReplenishHealth(int countHealth)
    {
        if (HealthCurrent + countHealth <= HealthMax)
            HealthCurrent += countHealth;
        else
            HealthCurrent = HealthMax;
    }
}
