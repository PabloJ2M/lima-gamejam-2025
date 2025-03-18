using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField] private LayerMask _mask;
    [SerializeField] private float _distance;

    public float Distance { private get => _distance; set => _distance = value; }

    public RaycastHit2D Detect(Vector2 direction) => Physics2D.Raycast(transform.position, direction, Distance, _mask);
}