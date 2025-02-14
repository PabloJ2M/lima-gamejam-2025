using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public float countdownTime = 5.0f;
    private float currentTime;
    public TextMeshProUGUI countdownText;

    void Start()
    {
        currentTime = countdownTime;
        Time.timeScale = 0;
        UpdateCountdownText();
    }

    void Update()
    {
        if (Time.timeScale == 0 && currentTime > 0)
        {
            currentTime -= Time.unscaledDeltaTime;
            UpdateCountdownText();

            if (currentTime <= 0)
            {
                currentTime = 0;
                Time.timeScale = 1;

                gameObject.SetActive(false);    
            }
        }
    }

    void UpdateCountdownText()
    {
        countdownText.text = Mathf.Ceil(currentTime).ToString();
    }
}
