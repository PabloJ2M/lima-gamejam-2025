using UnityEngine;

namespace Player.Controller
{
    public class Bounce : MonoBehaviour
    {
        [SerializeField] private float _force;
        private Movement _movement;
        private Rigidbody2D _body;

        private Vector2 _lastVelocity;

        private void Awake() { _movement = GetComponent<Movement>(); _body = GetComponent<Rigidbody2D>(); }
        private void LateUpdate() => _lastVelocity = _body.velocity.normalized;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!collision.collider.CompareTag("Bubble")) return;
            Vector2 normal = collision.contacts[0].normal;

            _body.AddForce(normal * _force * _lastVelocity.magnitude, ForceMode2D.Impulse);
            Destroy(collision.gameObject, 0.1f);
        }
    }
}