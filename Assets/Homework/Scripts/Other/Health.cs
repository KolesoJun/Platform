using System;
using UnityEngine;

abstract public class Health : MonoBehaviour
{
    [field: SerializeField] public float CountMax { get; protected set; }

    public float CountCurrent { get; protected set; }

    public event Action<float> ChangedCountCurrent;
    public event Action Died;

    private void Awake()
    {
        CountCurrent = CountMax;
    }

    public virtual void TakeDamage(float damage)
    {
        CountCurrent -= damage;
        
        if (CountCurrent <= 0)
        {
            CountCurrent = 0;
            Died?.Invoke();
        }

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
