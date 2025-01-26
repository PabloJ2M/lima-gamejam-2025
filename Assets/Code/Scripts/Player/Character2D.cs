using UnityEngine;
using static UnityEngine.Rendering.ProbeTouchupVolume;

public class Character2D : MonoBehaviour
{
    public Rigidbody2D body { get; private set; }
    public Collider2D shape { get; private set; }
    public Animator animator { get; private set; }

    public bool IsEnabled { get; set; }

    private void Awake()
    {
        IsEnabled = true;
        body = GetComponent<Rigidbody2D>();
        shape = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
    }
}