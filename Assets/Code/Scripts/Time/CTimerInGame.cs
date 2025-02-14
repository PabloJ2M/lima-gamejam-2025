using UnityEngine;
using TMPro;

public class CTimerInGame : MonoBehaviour
{
    public float countdownTime = 40.0f;
    private float currentTime;
    public TextMeshProUGUI countdownText;

    void Start()
    {
        currentTime = countdownTime;
        UpdateCountdownText();
    }

    void Update()
    {
        if (Time.timeScale == 1 && currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            UpdateCountdownText();

            if (currentTime <= 0)
            {
                currentTime = 0;
                Time.timeScale = 0;
                UpdateCountdownText();
            }
        }
    }

    void UpdateCountdownText()
    {
        countdownText.text = Mathf.Ceil(currentTime).ToString();
    }
}
