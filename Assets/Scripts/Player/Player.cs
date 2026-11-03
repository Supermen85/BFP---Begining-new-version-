using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Controller))]
[RequireComponent(typeof(DamageTaker))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Wallet))]

public class Player : MonoBehaviour
{
    private Mover _mover;
    private Controller _controller;
    private GroundController _groundController;
    private DamageTaker _damageTaker;
    private Health _health;
    private Wallet _wallet;
        
    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _controller = GetComponent<Controller>();
        _groundController = GetComponentInChildren<GroundController>();
        _damageTaker = GetComponent<DamageTaker>();
        _health = GetComponent<Health>();
        _wallet = GetComponent<Wallet>();
    }

    private void OnEnable()
    {
        _controller.Jumped += Jump;
        _controller.RunnedLeft += RunLeft;
        _controller.RunnedRight += RunRight;
        _groundController.Grounded += Land;
        _damageTaker.Damaged += TakeDamage;
    }

    private void OnDisable()
    {
        _controller.Jumped -= Jump;
        _controller.RunnedLeft -= RunLeft;
        _controller.RunnedRight -= RunRight;
        _groundController.Grounded -= Land;
        _damageTaker.Damaged -= TakeDamage;
    }

    public void PickMedkit(Medkit medkit)
    {
        _health.Heal(medkit);
    }

    public void PickCoin(Coin coin)
    {
        _wallet.PickCoin(coin);
    }

    private void TakeDamage(Vector2 enemyPosition, int damage)
    {
        _health.TakeDamge(damage);
        
        _mover.Knockback(enemyPosition);
    }

    private void Jump()
    {
        if (_groundController.CanJump())
            _mover.Jump();
    }

    private void Land()
    {
        _mover.Land();
    }

    private void RunLeft(bool isRunning)
    {
        _mover.RunLeft(isRunning);
    }

    private void RunRight(bool isRunning)
    {
        _mover.RunRight(isRunning);
    }
}
