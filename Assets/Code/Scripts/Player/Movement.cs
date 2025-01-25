using UnityEngine;

namespace Player.Controller
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float _speed = 10;
        [SerializeField] private float _accelRate = 25;

        private Rigidbody2D _body;
        private int _input;

        private void Awake() => _body = GetComponent<Rigidbody2D>();

        //lectura de input horizontal => -1 | 0 | 1
        private void Update() => _input = (int)Input.GetAxisRaw("Horizontal");

        private void FixedUpdate()
        {
            //calculo de movimiento
            float targetSpeed = _input * _speed;
            float speedDif = targetSpeed - _body.velocity.x;
            float movement = speedDif * _accelRate;

            //cambio de direccion
            if (_input != 0) transform.localScale = new Vector3(_input, 1, 1);

            //aplicacion de fuerza
            if (movement != 0) _body.AddForce(movement * Vector2.right, ForceMode2D.Force);
        }
    }
}