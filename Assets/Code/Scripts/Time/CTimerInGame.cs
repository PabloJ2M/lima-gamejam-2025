using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class CTimerInGame : MonoBehaviour
{
    public float countdownTime = 40.0f;
    private float currentTime;
    public TextMeshProUGUI countdownText;
    public TextMeshProUGUI timeoutText;
    public AudioSource audioSource;
    public AudioClip timeoutSound;
    public Canvas endGameCanvas;
    public float canvasDelay = 1.5f;
    public float textMoveSpeed = 200;

    private bool isTimeoutTriggered = false;

    void Start()
    {
        currentTime = countdownTime;
        UpdateCountdownText();
        timeoutText.gameObject.SetActive(false);
        endGameCanvas.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Time.timeScale == 1 && currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            UpdateCountdownText();

            if (currentTime <= 0 && !isTimeoutTriggered)
            {
                currentTime = 0;
                Time.timeScale = 0;
                TriggerTimeout();
            }
        }
    }

    void UpdateCountdownText()
    {
        countdownText.text = Mathf.Ceil(currentTime).ToString();
    }

    void TriggerTimeout()
    {
        isTimeoutTriggered = true;
        timeoutText.gameObject.SetActive(true);
        audioSource.PlayOneShot(timeoutSound);
        StartCoroutine(MoveTextToCenter());
    }

    IEnumerator MoveTextToCenter()
    {
        RectTransform textTransform = timeoutText.rectTransform;
        Vector2 startPos = textTransform.anchoredPosition;
        Vector2 targetPos = new Vector2(0, -530);
        float elapsedTime = 0f;
        float duration = 1f;

        while (elapsedTime < duration)
        {
            textTransform.anchoredPosition = Vector2.Lerp(startPos, targetPos, elapsedTime / duration);
            elapsedTime += Time.unscaledDeltaTime;
            yield return null;
        }

        textTransform.anchoredPosition = targetPos;
        yield return new WaitForSecondsRealtime(canvasDelay);
        timeoutText.gameObject.SetActive(false);
        endGameCanvas.gameObject.SetActive(true);
        
    }
}
