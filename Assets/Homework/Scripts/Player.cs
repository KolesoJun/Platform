using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _coins;

    public void AddCoin(int value)
    {
        _coins += value;
        Debug.Log(_coins);
    }
}