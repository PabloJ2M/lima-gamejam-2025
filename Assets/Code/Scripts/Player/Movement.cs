using UnityEngine;
using UnityEngine.InputSystem;

namespace Player.Controller
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float _speed = 10;
        [SerializeField] private float _accelRate = 25;

        public float Speed => _speed;
        private Character2D _character;
        private Vector2 _input;

        private void Awake() => _character = GetComponent<Character2D>();
        private void OnMove(InputValue value)
        {
            if (!_character.IsEnabled) return;

            _input = value.Get<Vector2>();
            _character.animator.SetFloat("Speed", Mathf.Abs(_input.x));
            Timer.Instance.HasStarted = true;
        }

        private void FixedUpdate()
        {
            if (!_character.IsEnabled) _input.x = 0;

            //calculo de movimiento
            float targetSpeed = _input.x * _speed;
            float speedDif = targetSpeed - _character.body.velocity.x;
            float movement = speedDif * _accelRate;

            //cambio de direccion
            if (_input.x != 0) transform.localScale = new Vector3(_input.x > 0 ? 1 : -1, 1, 1);

            //aplicacion de fuerza
            if (_input.x != 0) _character.body.AddForce(movement * Vector2.right, ForceMode2D.Force);
        }
    }
}