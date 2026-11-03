using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _health = 100;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null) 
        {
            _health--;
            Debug.Log("Враг получил урон");
        }

        if (IsDead())
            Debug.Log("Враг погиб");
    }

    private bool IsDead()
    {
        return _health <= 0;
    }
}
