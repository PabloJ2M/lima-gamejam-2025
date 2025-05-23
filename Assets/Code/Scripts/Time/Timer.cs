using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private InputActionReference _input;
    [SerializeField] private TextMeshProUGUI _timer;

    public static float elapsedTime;
    public static bool isCompleted;
    private bool _hasStarted;

    private void Awake() => _input.action.performed += InputCallback;
    private void Start() { isCompleted = false; DisplayTimer(); }
    private void OnEnable() => _input.action.Enable();
    private void OnDisable() => _input.action.Disable();
    private void InputCallback(InputAction.CallbackContext ctx) => _hasStarted = true;

    private void Update()
    {
        if (!_hasStarted || isCompleted) return;
        elapsedTime += Time.deltaTime;
        DisplayTimer();
    }
    private void DisplayTimer()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);
        int milliseconds = Mathf.FloorToInt((elapsedTime * 1000f) % 1000f);
        _timer?.SetText($"{minutes:00}:{seconds:00}:{milliseconds:00}");
    }
}