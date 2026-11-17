using UnityEngine;

[RequireComponent(typeof(MovementController))]
[RequireComponent(typeof(DamageTaker))]
[RequireComponent(typeof(Wallet))]
[RequireComponent(typeof(InputReader))]

public class Player : MonoBehaviour
{
    [field: SerializeField] public float Damage { get; private set; } = 25;

    private Health _health;
    private Wallet _wallet;

    private InputReader _inputReader;
    private LifeDrain _lifeDrain;
    private MovementController _movementController;
    private DamageTaker _damageTaker;

    private CoinCollector _coinCollector;
    private MedkitCollector _medkitCollector;

    private void Awake()
    {
        _health = GetComponentInChildren<Health>();
        _wallet = GetComponent<Wallet>();

        _inputReader = GetComponent<InputReader>();
        _lifeDrain = GetComponentInChildren<LifeDrain>();
        _movementController = GetComponent<MovementController>();
        _damageTaker = GetComponent<DamageTaker>();
 
        _coinCollector = GetComponentInChildren<CoinCollector>();
        _medkitCollector = GetComponentInChildren<MedkitCollector>();
    }

    private void OnEnable()
    {
        _damageTaker.DamagedByEnemy += DamageByEnemy;
        _health.Died += Die;
        _inputReader.Jumped += Jump;
        _inputReader.AbilityActivated += VampirismActivate;
        _coinCollector.Picked += PickCoin;
        _medkitCollector.Picked += PickMedkit;
        _lifeDrain.Healed += LifeDrain;
    }

    private void OnDisable()
    {
        _damageTaker.DamagedByEnemy -= DamageByEnemy;
        _health.Died -= Die;
        _inputReader.Jumped -= Jump;
        _inputReader.AbilityActivated -= VampirismActivate;
        _coinCollector.Picked -= PickCoin;
        _medkitCollector.Picked -= PickMedkit;
        _lifeDrain.Healed -= LifeDrain;
    }

    private void FixedUpdate()
    {
        _movementController.Run(_inputReader.Direction);
    }

    private void VampirismActivate()
    {
        _lifeDrain.Activate();
    }

    private void Jump()
    {
        _movementController.Jump();
    }

    private void LifeDrain(float value)
    {
        _health.Heal(value);
    }

    private void PickMedkit(Medkit medkit)
    {
        _health.Heal(medkit.GetValue());
    }

    private void PickCoin(Coin coin)
    {
        _wallet.PickCoin(coin);
    }

    private void DamageByEnemy(Vector2 enemyPosition, float damage)
    {
        TakeDamage(damage);
        KnockBack(enemyPosition);
    }

    private void TakeDamage(float damage)
    {
        _health.TakeDamge(damage);
    }

    private void KnockBack(Vector2 enemyPosition)
    {
        _movementController.Knockback(enemyPosition);
    }

    private void Die()
    {
        this.gameObject.SetActive(false);
    }
}
