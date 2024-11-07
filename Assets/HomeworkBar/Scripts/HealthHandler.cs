using System;
using UnityEngine;

abstract public class HealthHandler : MonoBehaviour
{
    [field: SerializeField] public float HealthMax { get; protected set; }

    public float HealthCurrent { get; protected set; }

    public event Action Died;
    public event Action<float> ChangedCurrentHealth;

    private void Start()
    {
        HealthCurrent = HealthMax;
        ChangedCurrentHealth?.Invoke(HealthCurrent);
    }

    public virtual void TakeDamage(float damage)
    {
        if (HealthCurrent - damage <= 0)
        {
            Died?.Invoke();
        }
        else
        {
            HealthCurrent -= damage;
            ChangedCurrentHealth?.Invoke(HealthCurrent);
        }
    }
}
