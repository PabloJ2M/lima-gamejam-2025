using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ObjectMovement : MonoBehaviour
{
    public Vector2 Direction { private get; set; }
    public float Speed { private get; set; }

    private Rigidbody2D _body;
    
    private void Awake() => _body = GetComponent<Rigidbody2D>();
    private void FixedUpdate()
    {
        if (Direction == Vector2.zero) return;
        _body?.MovePosition(_body.position + Direction * (Speed * Time.fixedDeltaTime));
    }
}