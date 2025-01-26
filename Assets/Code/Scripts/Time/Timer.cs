using UnityEngine;
using TMPro;

public class Timer : SingletonBasic<Timer>
{
    [SerializeField] private TextMeshProUGUI _timer;
    public bool HasStarted { private get; set; }
    private float _elapsedTime = 0f;

    private void Update()
    {
        if (!HasStarted) return;
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