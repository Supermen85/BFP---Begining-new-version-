using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] private int _force = 8;

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponentInParent<Rigidbody2D>();
    }

    public void Jump()
    {
        _rigidbody2D.AddForce(Vector2.up * _force, ForceMode2D.Impulse);
    }
}
