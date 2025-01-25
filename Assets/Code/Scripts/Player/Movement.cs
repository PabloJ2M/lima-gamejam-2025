using UnityEngine;
using UnityEngine.InputSystem;

namespace Player.Controller
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float _speed = 10;
        [SerializeField] private float _accelRate = 25;

        public float Speed => _speed;
        private Rigidbody2D _body;
        private int _input;

        public bool HasStartedMoving { get; private set; }

        private void Awake() => _body = GetComponent<Rigidbody2D>();
        private void Start() => Time.timeScale = 0;
        private void OnMove(InputValue value)
        {
            _input = (int)value.Get<Vector2>().x;
            if (!HasStartedMoving && _input != 0) { HasStartedMoving = true; Time.timeScale = 1; }
        }

        private void FixedUpdate()
        {
            //calculo de movimiento
            float targetSpeed = _input * _speed;
            float speedDif = targetSpeed - _body.velocity.x;
            float movement = speedDif * _accelRate;

            //cambio de direccion
            if (_input != 0) transform.localScale = new Vector3(_input, 1, 1);

            //aplicacion de fuerza
            if (_input != 0) _body.AddForce(movement * Vector2.right, ForceMode2D.Force);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Finish"))
            {
                Timer timer = FindObjectOfType<Timer>(); 
                timer.enabled = false; //desactiva el temporizador, trate de hacer que se desactivara con una funcion re piola pero fracase x-x
            }
        }
    }
}