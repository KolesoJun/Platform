using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [field: SerializeField] public float Value { get; private set; }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
