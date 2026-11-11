using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner<T> : MonoBehaviour where T : Item
{
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private T _itemPrefab;

    private T _item;
    private Vector2 _spawnPosition;

    private void Awake()
    {
        _item = Instantiate(_itemPrefab, transform.position, Quaternion.identity);
        _item.gameObject.SetActive(false);
    }

    private void Start()
    {
        ReSpawn();
    }

    private void OnEnable()
    {
        _item.Picked += ReSpawn;
    }

    private void OnDisable()
    {
        _item.Picked -= ReSpawn;
    }

    private void ReSpawn()
    {
        _item.gameObject.SetActive(false);

        SetRandomPosition();

        StartCoroutine(Enable());
    }

    private void SetRandomPosition()
    {
        _spawnPosition = _spawnPoints[Random.Range(0, _spawnPoints.Count)].position;
    }

    private IEnumerator Enable()
    {
        int time = 2;
        var wait = new WaitForSeconds(time);

        yield return wait;

        while (IsPlayerFarEnough() == false)
        {
            yield return wait;
        }

        _item.SetPosition(_spawnPosition);
        _item.gameObject.SetActive(true);
    }

    private bool IsPlayerFarEnough()
    {
        float radius = 0.4f;
        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_spawnPosition, radius);

        foreach (Collider2D collider in colliders)
        {
            if (collider.GetComponent<Player>() == true)
                return false;
        }

        return true;
    }
}
