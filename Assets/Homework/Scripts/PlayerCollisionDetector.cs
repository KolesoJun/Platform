using UnityEngine;

public class PlayerCollisionDetector : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            _player.AddCoin(coin.Value);
            Destroy(coin.gameObject);
        }
    }
}
