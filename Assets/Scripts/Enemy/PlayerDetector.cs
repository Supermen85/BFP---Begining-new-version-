using System;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    public Action<Vector2> PlayerEntered;
    public Action PlayerExited;

    private GameObject _target = null;

    private void Update()
    {
        if (_target != null)
            PlayerEntered?.Invoke(_target.transform.position);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
            _target = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            _target = null;
            PlayerExited?.Invoke();
        }
    }
}
