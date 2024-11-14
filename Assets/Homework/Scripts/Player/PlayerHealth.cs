using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField] private PlayerInteractor _playerInteractor;

    private void OnEnable()
    {
        _playerInteractor.TouchedMedicine += Replenish;
    }

    private void OnDisable()
    {
        _playerInteractor.TouchedMedicine -= Replenish;
    }
}
