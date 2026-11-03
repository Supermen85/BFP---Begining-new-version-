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

        Debug.Log($"Вы подобрали монеты: {value}.");

        _coins += value;

        Show();
    }

    private void Show()
    {
        Debug.Log($"У вас монет: {_coins}.");
    }
}
