using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField] private Player _player;

    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private Medkit _medkitPrefab;

    [SerializeField] private List<Transform> _coinSpawnPoints;
    [SerializeField] private List<Transform> _medkitSpawnPoints;

    private Coin _coin;
    private Medkit _medkit;

    private void Awake()
    {
        _coin = Instantiate(_coinPrefab, transform.position, Quaternion.identity);
        _coin.SetSpawnPoints(_coinSpawnPoints);
        _coin.Spawn();
        _coin.Picked += Picking;

        _medkit = Instantiate(_medkitPrefab, transform.position, Quaternion.identity);
        _medkit.SetSpawnPoints(_medkitSpawnPoints);
        _medkit.Spawn();
        _medkit.Picked += Picking;
    }

    private void Picking(Item item)
    {
        if (item.GetType() == typeof(Coin))
        {
            Debug.Log("Pick coin");
            _player.PickCoin((Coin)item);
        }

        if (item.GetType() == typeof(Medkit))
        {
            Debug.Log("Pick Medkit");
            _player.PickMedkit((Medkit)item);
        }

        item.Spawn();
    }
}
