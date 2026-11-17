using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private float _startingCoins = 0;

    private float _coins;

    private void Awake()
    {
        _coins = _startingCoins;
    }

    public void PickCoin(Coin coin)
    {
        float value = coin.GetValue();
        
        if (value <= 0)
            return;

        _coins += value;
    }
}
