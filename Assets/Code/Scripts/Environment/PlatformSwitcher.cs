using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Environment
{
    public enum Side { Left, Right }

    public class PlatformSwitcher : SingletonBasic<PlatformSwitcher>
    {
        [SerializeField] private InputActionReference _input;
        [SerializeField] private Side _currentSide;

        public event Action<Side> onDirectionChanged;

        protected override void Awake() { base.Awake(); _input.action.performed += InputCallback; }
        private void Start() => SetDirection(_currentSide);
        private void OnEnable() => _input.action.Enable();
        private void OnDisable() => _input.action.Disable();

        private void OnValidate() => SetDirection(_currentSide);
        private void InputCallback(InputAction.CallbackContext ctx) => SwipeDirectin();

        private void SetDirection(Side value) => onDirectionChanged?.Invoke(value);
        private void SwipeDirectin()
        {
            _currentSide = _currentSide.Equals(Side.Left) ? Side.Right : Side.Left;
            SetDirection(_currentSide);
        }
    }
}