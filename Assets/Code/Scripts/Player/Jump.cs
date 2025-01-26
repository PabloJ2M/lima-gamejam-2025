using UnityEngine;
using UnityEngine.Events;

namespace Player.Controller
{
    public class Jump : MonoBehaviour
    {
        [SerializeField] private float _force, _coyoteTime = 0.2f;
        [SerializeField] private UnityEvent _onDoubleJump;

        [Header("Detection")]
        [SerializeField] private LayerMask _groundMask;
        [SerializeField, Range(0, 2)] private float _size = 0.5f, _distance = 1;

        private Character2D _character;
        private bool _isGrounded, _coyoteJump, _secondJump;
        private float _fallTime;

        private void Awake() => _character = GetComponent<Character2D>();
        private void Update()
        {
            _character.animator.SetInteger("Gravity", (int)_character.body.velocityY);
            _isGrounded = Physics2D.BoxCast(transform.position, _size * Vector2.one, 0, Vector2.down, _distance, _groundMask);
            _coyoteJump = _character.body.velocity.y <= 0 && _fallTime < _coyoteTime;
            _fallTime = _isGrounded ? 0 : _fallTime += Time.deltaTime;
            if (_isGrounded) _secondJump = true;
        }

        private void OnJump()
        {
            if (!_character.IsEnabled) return;
            if (!_isGrounded && !_coyoteJump && !_secondJump) return;

            _character.body.velocityY = 0;
            _character.body.AddForce(_force * Vector2.up, ForceMode2D.Impulse);
            if (!_isGrounded && !_coyoteJump) { _onDoubleJump.Invoke(); _secondJump = false; }
        }
    }
}