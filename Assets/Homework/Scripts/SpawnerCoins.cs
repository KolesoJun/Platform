using UnityEngine;

public class SpawnerCoins : MonoBehaviour
{
    [SerializeField] private Coin _prefab;
    [SerializeField] private PointSpawnCoin[] _points;

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        for (int i = 0; i < _points.Length; i++)
        {
            Coin coin = Instantiate(_prefab, transform);
            coin.transform.position = _points[i].transform.position;
        }
    }
}
