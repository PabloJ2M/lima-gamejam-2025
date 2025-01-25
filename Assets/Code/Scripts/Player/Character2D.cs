using UnityEngine;

public class Character2D : MonoBehaviour
{
    public Rigidbody2D body { get; private set; }
    public Animator animator { get; private set; }

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
}