using UnityEngine;

[RequireComponent(typeof(PlayerWallet))]
[RequireComponent(typeof(PlayerHealth))]
public class PlayerInteractor : MonoBehaviour
{
    private PlayerWallet _wallet;
    private PlayerHealth _specifications;

    private void Awake()
    {
        _wallet = GetComponent<PlayerWallet>();
        _specifications = GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            _wallet.AddCoin(coin.Value);
            Destroy(coin.gameObject);
        }

        if (collision.TryGetComponent(out MedicineKit medicine))
        {
            _specifications.ReplenishHealth(medicine.CountHealth);
            Destroy(medicine.gameObject);
        }
    }
}
