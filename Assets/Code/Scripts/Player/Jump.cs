using UnityEngine;

namespace Player.Controller
{
    public class Jump : MonoBehaviour
    {
        [SerializeField] private float _force, _coyoteTime = 0.2f;
        
        [Header("Detection")]
        [SerializeField] private LayerMask _groundMask;
        [SerializeField, Range(0, 2)] private float _size = 0.5f, _distance = 1;

        private Rigidbody2D _body;

        private bool _isGrounded, _coyoteJump, _secondJump;
        private float _fallTime;

        private void Awake() => _body = GetComponent<Rigidbody2D>();
        private void Update()
        {
            _isGrounded = Physics2D.BoxCast(transform.position, _size * Vector2.one, 0, Vector2.down, _distance, _groundMask);
            _coyoteJump = _body.velocity.y <= 0 && _fallTime < _coyoteTime;
            _fallTime = _isGrounded ? 0 : _fallTime += Time.deltaTime;
            if (_isGrounded) _secondJump = true;
        }

        private void OnJump()
        {
            if (!_isGrounded && !_coyoteJump && !_secondJump) return;

            _body.velocityY = 0;
            _body.AddForce(_force * Vector2.up, ForceMode2D.Impulse);
            if (!_isGrounded && !_coyoteJump) _secondJump = false;
        }
    }
}