using UnityEngine;

[RequireComponent(typeof(MovementController))]
[RequireComponent(typeof(DamageTaker))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Wallet))]

public class Player : MonoBehaviour
{
    [field: SerializeField] public int Damage { get; private set; } = 1;

    private MovementController _movementController;
    private DamageTaker _damageTaker;
    private Health _health;
    private Wallet _wallet;

    private void Awake()
    {
        _movementController = GetComponent<MovementController>();
        
        _damageTaker = GetComponent<DamageTaker>();
        _health = GetComponent<Health>();
        _wallet = GetComponent<Wallet>();
    }

    private void OnEnable()
    {
        _damageTaker.DamagedByEnemy += TakeDamage;
        _health.Died += Die;
    }

    private void OnDisable()
    {
        _damageTaker.DamagedByEnemy -= TakeDamage;
        _health.Died -= Die;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            _movementController.Jump();

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            _movementController.StartRunLeft();

        if (Input.GetKeyDown(KeyCode.RightArrow))
            _movementController.StartRunRight();

        if (Input.GetKeyUp(KeyCode.LeftArrow))
            _movementController.StopRunLeft();

        if (Input.GetKeyUp(KeyCode.RightArrow))
            _movementController.StopRunRight();
    }

    private void FixedUpdate()
    {
        _movementController.Run();
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
