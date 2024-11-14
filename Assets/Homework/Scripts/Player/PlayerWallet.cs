using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    [SerializeField] private PlayerInteractor _playerInteractor;

    private float _coins;

    private void OnEnable()
    {
        _playerInteractor.TouchedCoin += AddCoin;
    }

    private void OnDisable()
    {
        _playerInteractor.TouchedCoin -= AddCoin;
    }

    public void AddCoin(float value)
    {
        _coins += value;
    }
}
