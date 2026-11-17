using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class LifeDrainRenderer : MonoBehaviour
{
    [SerializeField] private LifeDrain _lifeDrain;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _spriteRenderer.enabled = false;
    }

    private void OnEnable()
    {
        _lifeDrain.ActivateChanged += ActivateChange;
    }

    private void OnDisable()
    {
        _lifeDrain.ActivateChanged -= ActivateChange;
    }

    private void ActivateChange(bool IsActivated)
    {
        _spriteRenderer.enabled = IsActivated;
    }
}
