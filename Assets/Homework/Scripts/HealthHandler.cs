using System;
using UnityEngine;

abstract public class HealthHandler : MonoBehaviour
{
    [SerializeField] protected int HealthMax;

    protected int HealthCurrent;

    public event Action Died;

    private void Start()
    {
        HealthCurrent = HealthMax;
    }

    public virtual void TakeDamage(int damage)
    {
        if (HealthCurrent - damage <= 0)
            Died?.Invoke();
        else
            HealthCurrent -= damage;
    }
}
