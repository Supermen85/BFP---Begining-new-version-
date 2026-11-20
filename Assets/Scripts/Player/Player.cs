using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(MovementController))]
[RequireComponent(typeof(PlayerDamageTaker))]
[RequireComponent(typeof(Wallet))]
[RequireComponent(typeof(InputReader))]

public class Player : MonoBehaviour, IAttackable
{
    [field: SerializeField] public float Damage { get; private set; } = 25;

    public Vector3 Position => transform.position;

    [SerializeField] private LifeDrain _lifeDrain;
    [SerializeField] private CoinCollector _coinCollector;
    [SerializeField] private MedkitCollector _medkitCollector;

    private Health _health;
    private Wallet _wallet;
    private InputReader _inputReader;
    private MovementController _movementController;
    private PlayerDamageTaker _playerDamageTaker;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _wallet = GetComponent<Wallet>();
        _inputReader = GetComponent<InputReader>();
        _movementController = GetComponent<MovementController>();
        _playerDamageTaker = GetComponent<PlayerDamageTaker>();
    }

    private void OnEnable()
    {
        _playerDamageTaker.DamagedWithKnockback += DamageByEnemy;
        _health.Died += Die;
        _inputReader.Jumped += Jump;
        _inputReader.AbilityActivated += LifeDrainActivate;
        _coinCollector.Picked += PickCoin;
        _medkitCollector.Picked += PickMedkit;
        _lifeDrain.Healed += LifeDrain;
    }

    private void OnDisable()
    {
        _playerDamageTaker.DamagedWithKnockback -= DamageByEnemy;
        _health.Died -= Die;
        _inputReader.Jumped -= Jump;
        _inputReader.AbilityActivated -= LifeDrainActivate;
        _coinCollector.Picked -= PickCoin;
        _medkitCollector.Picked -= PickMedkit;
        _lifeDrain.Healed -= LifeDrain;
    }

    private void FixedUpdate()
    {
        _movementController.Run(_inputReader.Direction);
    }

    private void LifeDrainActivate()
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

    private void DamageByEnemy(Vector3 enemyPosition, float damage)
    {
        TakeDamage(damage);
        KnockBack(enemyPosition);
    }

    private void TakeDamage(float damage)
    {
        _health.TakeDamge(damage);
    }

    private void KnockBack(Vector3 enemyPosition)
    {
        _movementController.Knockback(enemyPosition);
    }

    private void Die()
    {
        this.gameObject.SetActive(false);
    }
}
