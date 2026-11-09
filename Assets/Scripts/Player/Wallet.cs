using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int _startingCoins = 0;

    private int _coins;

    private void Awake()
    {
        _coins = _startingCoins;
    }

    public void PickCoin(Coin coin)
    {
        int value = coin.GetValue();
        
        if (value <= 0)
            return;

        _coins += value;
    }
}
