using UnityEngine;

public class Character2D : MonoBehaviour
{
    public Rigidbody2D body { get; private set; }

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
}