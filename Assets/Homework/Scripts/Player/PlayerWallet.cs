using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    private int _coins;

    public void AddCoin(int value)
    {
        _coins += value;
        Debug.Log(_coins);
    }
}
