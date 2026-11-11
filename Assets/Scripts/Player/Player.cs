using UnityEngine;

[RequireComponent(typeof(MovementController))]
[RequireComponent(typeof(DamageTaker))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Wallet))]
[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(CoinCollector))]
[RequireComponent(typeof(MedkitCollector))]

public class Player : MonoBehaviour
{
    [field: SerializeField] public int Damage { get; private set; } = 1;

    private MovementController _movementController;
    private DamageTaker _damageTaker;
    private Health _health;
    private Wallet _wallet;
    private InputReader _inputReader;

    private CoinCollector _coinCollector;
    private MedkitCollector _medkitCollector;

    private void Awake()
    {
        _movementController = GetComponent<MovementController>();
        _damageTaker = GetComponent<DamageTaker>();
        _health = GetComponent<Health>();
        _wallet = GetComponent<Wallet>();
        _inputReader = GetComponent<InputReader>();
        _coinCollector = GetComponent<CoinCollector>();
        _medkitCollector = GetComponent<MedkitCollector>();
    }

    private void OnEnable()
    {
        _damageTaker.DamagedByEnemy += TakeDamage;
        _health.Died += Die;
        _inputReader.Jumped += Jump;
        _coinCollector.Picked += PickCoin;
        _medkitCollector.Picked -= PickMedkit;
    }

    private void OnDisable()
    {
        _damageTaker.DamagedByEnemy -= TakeDamage;
        _health.Died -= Die;
        _inputReader.Jumped -= Jump;
        _coinCollector.Picked -= PickCoin;
        _medkitCollector.Picked -= PickMedkit;
    }

    private void FixedUpdate()
    {
        _movementController.Run(_inputReader.Direction);
    }

    private void Jump()
    {
        _movementController.Jump();
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
        
        _movementController.Knockback(enemyPosition);
    }

    private void Die()
    {
        this.gameObject.SetActive(false);
    }
}
