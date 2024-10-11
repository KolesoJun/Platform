using UnityEngine;

[RequireComponent(typeof(PlayerWallet))]
public class PlayerInteractor : MonoBehaviour
{
    private PlayerWallet _wallet;

    private void Awake()
    {
        _wallet = GetComponent<PlayerWallet>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            _wallet.AddCoin(coin.Value);
            Destroy(coin.gameObject);
        }
    }
}
