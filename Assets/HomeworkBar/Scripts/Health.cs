using System;
using UnityEngine;

abstract public class Health : MonoBehaviour
{
    [field: SerializeField] public float CountMax { get; protected set; }

    public float CountCurrent { get; protected set; }

    public event Action<float> ChangedCountCurrent;

    private void Start()
    {
        CountCurrent = CountMax;
        ChangedCountCurrent?.Invoke(CountCurrent);
    }

    public virtual void TakeDamage(float damage)
    {
        CountCurrent -= damage;
        
        if (CountCurrent <= 0)
            CountCurrent = 0;

        ChangedCountCurrent?.Invoke(CountCurrent);
    }

    public void ReplenishHealth(float countHealth)
    {
        if (CountCurrent + countHealth < CountMax)
            CountCurrent += countHealth;
        else
            CountCurrent = CountMax;

        ChangedCountCurrent?.Invoke(CountCurrent);
    }
}
