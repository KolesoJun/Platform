using System;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    public event Action<float> TouchedCoin;
    public event Action<float> TouchedMedicine;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            TouchedCoin?.Invoke(coin.Value);
            coin.Destroy();
        }

        if (collision.TryGetComponent(out MedicineKit medicine))
        {
            TouchedMedicine?.Invoke(medicine.Value);
            medicine.Destroy();
        }
    }
}
