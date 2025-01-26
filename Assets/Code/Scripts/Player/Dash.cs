using UnityEngine;

namespace Player.Controller
{
    public class Dash : MonoBehaviour
    {
        [SerializeField] private float _force;
        private Character2D _character;

        private void Awake() => _character = GetComponent<Character2D>();

        private void OnDash()
        {
            if (!_character.IsEnabled) return;

            _character.body.velocityY = 0;
            _character.body.AddForce(new Vector2(transform.localScale.x, 1) * _force, ForceMode2D.Impulse);
        }
    }
}