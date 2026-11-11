using System;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    public event Action<Transform> PlayerEntered;
    public event Action PlayerExited;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() == null)
            return;

        Transform playerTransform = collision.GetComponent<Transform>();

        PlayerEntered?.Invoke(playerTransform);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() == null)
            return;
        
        PlayerExited?.Invoke();
    }
}
