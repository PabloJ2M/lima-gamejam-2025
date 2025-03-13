using UnityEngine;

namespace Environment
{
    public class PlatformSwitcherListener : MonoBehaviour
    {
        [SerializeField] private Transform _render;
        [SerializeField, Range(0, 1)] private float _time = 0.5f;
        [SerializeField] private Color _left, _right;
        [SerializeField] private Collider2D _leftCollider, _rightCollider;

        private PlatformSwitcher _controller;
        private SpriteRenderer _sprite;

        private void Awake() { _controller = PlatformSwitcher.Instance; _sprite = _render.GetComponentInChildren<SpriteRenderer>(); }
        private void OnEnable() => _controller.onDirectionChanged += OnPerformePolarity;
        private void OnDisable() => _controller.onDirectionChanged -= OnPerformePolarity;

        private void OnPerformePolarity(Side value)
        {
            bool isLeft = value.Equals(Side.Left);
            LeanTween.rotateY(_render.gameObject, isLeft ? 0 : 180, _time).setOnUpdate(OnUpdate);

            void OnUpdate(float value)
            {
                if (value < 0.5f) return;
                _sprite.color = isLeft ? _left : _right;
                _leftCollider.enabled = isLeft;
                _rightCollider.enabled = !isLeft;
            }
        }
    }
}