using UnityEngine.InputSystem;

namespace UnityEngine.Tutorial
{
    public class EventInput : EventSender
    {
        [SerializeField] private InputAction _action;

        private void Start() => _action.performed += OnPerforme;
        private void OnEnable() => _action.Enable();
        private void OnDisable() => _action.Disable();
        private void OnPerforme(InputAction.CallbackContext ctx) => Interact();
    }
}