using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private InputActionReference _input;
    [SerializeField] private TextMeshProUGUI _timer;

    private bool _hasStarted;
    private float _elapsedTime;

    private void Awake() => _input.action.performed += InputCallback;
    private void OnEnable() => _input.action.Enable();
    private void OnDisable() => _input.action.Disable();
    private void InputCallback(InputAction.CallbackContext ctx) => _hasStarted = true;

    private void Update()
    {
        if (!_hasStarted) return;
        _elapsedTime += Time.deltaTime;
        changeTimer();
    }
    private void changeTimer()
    {
        int minutes = Mathf.FloorToInt(_elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(_elapsedTime % 60f);
        int milliseconds = Mathf.FloorToInt((_elapsedTime * 1000f) % 1000f);
        _timer.text = $"{minutes:00}:{seconds:00}:{milliseconds:00}";
    }
}