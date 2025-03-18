using Events.Interact;
using UnityEngine;

namespace Environment
{
    [SelectionBase] [RequireComponent(typeof(CircleCollider2D), typeof(Raycast))]
    public class LookTracker : MonoBehaviour
    {
        [SerializeField] private Transform _look;
        [SerializeField] private string _tag = "Player";
        [SerializeField] private float _speed, _maxDistance;

        private CircleCollider2D _area;
        private Collider2D _player;
        private Raycast _ray;
        private Delay _delay;

        private void Awake()
        {
            _area = GetComponent<CircleCollider2D>();
            _ray = GetComponent<Raycast>();
            _delay = GetComponent<Delay>();
        }
        private void Update()
        {
            if (_player == null) { SmoothMovement(Vector2.zero); return; }
            _ray.Distance = _area.radius;

            Vector2 directon = _player.transform.position - transform.position;
            RaycastHit2D hit = _ray.Detect(directon);
            if (hit.collider.CompareTag(_tag)) _delay.Stop();

            if (_delay.IsPlaying) return;
            SmoothMovement(directon.normalized * _maxDistance);
            if (hit.collider.CompareTag(_tag)) _delay.PlatDefault();
        }

        private void SmoothMovement(Vector2 normal) => _look.localPosition = Vector2.Lerp(_look.localPosition, normal, Time.deltaTime * _speed);
        public void OnDetectionEnter(Collider2D player) => _player = player;
        public void OnDetectionExit(Collider2D player) => _player = null;
    }
}