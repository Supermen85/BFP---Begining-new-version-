using UnityEngine;

public class Pursuit : MonoBehaviour
{
    [field: SerializeField] public float Speed { get; private set; } = 1.5f;

    public bool IsPursuiting { get; private set; } = false;

    public void StartPursuit()
    {
        IsPursuiting = true;
    }

    public void StopPursuit()
    {
        IsPursuiting = false;
    }
}
