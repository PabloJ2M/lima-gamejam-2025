using UnityEngine;

namespace Player.Controller
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float _speed = 10;
        [SerializeField] private float _accelRate = 25;

        public float Speed => _speed;
        private Rigidbody2D _body;
        private int _input;

        public bool HasStartedMoving { get; private set; } = false; //booleano para ver si se empezo a mover o no el jugador
        private void Awake() => _body = GetComponent<Rigidbody2D>();
        private void Update()
        {
            _input = (int)Input.GetAxisRaw("Horizontal");

            if (!HasStartedMoving && _input != 0)
            {
                HasStartedMoving = true; //se vuelve true el booleano cuando detecta que _input (que es un int) es mayor a 0, osea cuando se usa una vez
            }
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